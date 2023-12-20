// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegistryUtility.cs" company="Soloplan GmbH">
//   Copyright (c) Soloplan GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace CLPatch
{
  using Microsoft.Win32;

  /// <summary>
  /// A utility class for managing Database-related registry entries.
  /// </summary>
  public abstract class RegistryUtility
  {
    /// <summary>
    /// Retrieves Oracle installation names and paths from the Windows Registry.
    /// </summary>
    /// <returns>A dictionary of Oracle Home Names and their paths.</returns>
    public static Dictionary<string, Tuple<string, string>> GetOracleInfo()
    {
      const string RegKey = @"SOFTWARE\ORACLE";
      const string SubKeyNamePattern = "KEY_OraDB";
      const string PathKey = "ORACLE_HOME";

      Dictionary<string, Tuple<string, string>> resultDictionary = new();

      using var key = Registry.LocalMachine.OpenSubKey(RegKey);
      if (key == null)
      {
        throw new InvalidOperationException($"Registry key '{RegKey}' not found.");
      }

      string[] subKeyNames = key.GetSubKeyNames();

      foreach (string subKeyName in subKeyNames)
      {
        if (!subKeyName.Contains(SubKeyNamePattern))
        {
          continue;
        }

        var value = key.OpenSubKey(subKeyName)?.GetValue(PathKey) as string;
        resultDictionary.Add(subKeyName, new Tuple<string, string>(subKeyName, value ?? string.Empty));
      }

      return resultDictionary;
    }
  }
}
