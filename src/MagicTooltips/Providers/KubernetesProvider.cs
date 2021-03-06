﻿using MagicTooltips.Services;

namespace MagicTooltips.Providers
{
  public class KubernetesProvider : IProvider
  {
    public string ProviderKey => "kubernetes";
    public string DefaultCommands => "kubectl,helm,kubens,kubectx,oc,istioctl,kogito,k9s,helmlist";
    public string DefaultNounPrefixes => null;
    public string DefaultFgColor => "#AE5FD6";
    public string DefaultBgColor => "";
    public string DefaultTemplate => "\ufd31 {value}";

    public string GetValue()
    {
      var script = "kubectl config view --minify --output 'jsonpath={...context.cluster}::{..namespace}'";
      return PowershellInvoker.InvokeScript(script);
    }
  }
}
