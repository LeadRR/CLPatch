// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceUtility.cs" company="Soloplan GmbH">
//   Copyright (c) Soloplan GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace CLPatch
{
  using System.ServiceProcess;

  /// <summary>
  /// Utility class for managing services.
  /// </summary>
  internal abstract class ServiceUtility
  {
    /// <summary>
    /// Stops all services that match the criteria defined in GetServices.
    /// </summary>
    /// <param name="richTextBox">The RichTextBox to which the status of the operation will be appended.</param>
    /// <returns>A Task representing the asynchronous operation.</returns>
    public static Task StopServices(RichTextBox richTextBox)
    {
      return ManageServices(
        ServiceControllerStatus.Running,
        service => service.Stop(),
        "Stopping",
        "stopped",
        richTextBox);
    }

    /// <summary>
    /// Starts all services that match the criteria defined in GetServices.
    /// </summary>
    /// <param name="richTextBox">The RichTextBox to which the status of the operation will be appended.</param>
    /// <returns>A Task representing the asynchronous operation.</returns>
    public static Task StartServices(RichTextBox richTextBox)
    {
      return ManageServices(
        ServiceControllerStatus.Stopped,
        service => service.Start(),
        "Starting",
        "started",
        richTextBox);
    }

    /// <summary>
    /// Manages services based on the provided parameters.
    /// </summary>
    /// <param name="statusToCheck">The status to check for the services.</param>
    /// <param name="actionOnService">The action to perform on the services.</param>
    /// <param name="actionInProgressText">The text to display while the action is in progress.</param>
    /// <param name="actionCompletedText">The text to display when the action is completed.</param>
    /// <param name="richTextBox">The RichTextBox to which the status of the operation will be appended.</param>
    /// <returns>A Task representing the asynchronous operation.</returns>
    private static async Task ManageServices(
      ServiceControllerStatus statusToCheck,
      Action<ServiceController> actionOnService,
      string actionInProgressText,
      string actionCompletedText,
      TextBoxBase richTextBox)
    {
      List<ServiceController> services = GetServices(statusToCheck);
      var failedServices = new List<string>();

      foreach (var service in services)
      {
        try
        {
          richTextBox.BeginInvoke(
            new Action<string>(richTextBox.AppendText),
            $"{actionInProgressText} service: {service.ServiceName}..\n");
          actionOnService(service);
          await Task.Run(() => service.WaitForStatus(statusToCheck == ServiceControllerStatus.Running ? ServiceControllerStatus.Stopped : ServiceControllerStatus.Running, TimeSpan.FromSeconds(120)));
          richTextBox.BeginInvoke(
            new Action<string>(richTextBox.AppendText),
            $"Service {service.ServiceName} {actionCompletedText} successfully.\n\n");
        }
        catch (Exception ex)
        {
          failedServices.Add(service.ServiceName);
          richTextBox.BeginInvoke(
            new Action<string>(richTextBox.AppendText),
            $"Failed to {actionCompletedText.ToLower()} service {service.ServiceName}: {ex.Message}\n\n");
        }
      }

      // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
      if (failedServices.Any())
      {
        richTextBox.BeginInvoke(new Action<string>(richTextBox.AppendText), $"The following services failed to {actionCompletedText.ToLower()}: {string.Join(", ", failedServices)}\n");
      }
      else
      {
        richTextBox.BeginInvoke(new Action<string>(richTextBox.AppendText), $"All services {actionCompletedText.ToLower()} successfully.\n");
      }
    }

    /// <summary>
    /// Gets a list of services that match the specified status and whose names contain "Oracle" or equal "msdtc".
    /// </summary>
    /// <param name="status">The status to match.</param>
    /// <returns>A list of matching services.</returns>
    public static List<ServiceController> GetServices(ServiceControllerStatus status)
    {
      List<ServiceController> services = new();
      ServiceController[] allServices = ServiceController.GetServices();

      // ReSharper disable once LoopCanBeConvertedToQuery
      foreach (var service in allServices)
      {
        if ((service.ServiceName.Contains("Oracle", StringComparison.OrdinalIgnoreCase)
             || service.ServiceName.Equals("msdtc", StringComparison.OrdinalIgnoreCase)) && service.Status == status)
        {
          services.Add(service);
        }
      }

      return services;
    }
  }
}
