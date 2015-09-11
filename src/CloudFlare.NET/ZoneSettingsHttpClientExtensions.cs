﻿namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Extension methods on <see cref="HttpClient"/> to wrap the Zone APIs
    /// </summary>
    /// <seealso href="https://api.cloudflare.com/#zone-settings"/>
    public static class ZoneSettingsHttpClientExtensions
    {
        /// <summary>
        /// Gets the zone settings for the zone with the specified <paramref name="zoneId"/>.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-all-zone-settings"/>
        public static async Task<IEnumerable<ZoneSettingBase>> GetAllZoneSettingsAsync(
            this HttpClient client,
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth)
        {
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            Uri uri = new Uri(CloudFlareConstants.BaseUri, $"zones/{zoneId}/settings");

            JArray jsonSettings = await client.GetCloudFlareResultAsync<JArray>(uri, auth, cancellationToken)
                .ConfigureAwait(false);

            return GetZoneSetting(jsonSettings.Cast<JObject>());
        }

        /// <summary>
        /// Advanced protection from Distributed Denial of Service (DDoS) attacks on your website.
        /// This is an uneditable value that is 'on' in the case of Business and Enterprise zones
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-advanced-ddos-setting"/>
        public static Task<ZoneSetting<SettingOnOffTypes>> GetAdvancedDdosSettingAsync(
            this HttpClient client,
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth)
        {
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            Uri uri = new Uri(CloudFlareConstants.BaseUri, $"zones/{zoneId}/settings/advanced_ddos");

            return client.GetCloudFlareResultAsync<ZoneSetting<SettingOnOffTypes>>(uri, auth, cancellationToken);
        }

        /// <summary>
        /// When enabled, Always Online will serve pages from our cache if your server is offline.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-always-online-setting"/>
        public static Task<ZoneSetting<SettingOnOffTypes>> GetAlwaysOnlineSettingAsync(
            this HttpClient client,
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth)
        {
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            Uri uri = new Uri(CloudFlareConstants.BaseUri, $"zones/{zoneId}/settings/always_online");

            return client.GetCloudFlareResultAsync<ZoneSetting<SettingOnOffTypes>>(uri, auth, cancellationToken);
        }

        /// <summary>
        /// Browser Cache TTL (in seconds) specifies how long CloudFlare-cached resources will remain on your visitors'
        /// computers.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-browser-cache-ttl-setting"/>
        public static Task<ZoneSetting<int>> GetBrowserCacheTtlSettingAsync(
            this HttpClient client,
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth)
        {
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            Uri uri = new Uri(CloudFlareConstants.BaseUri, $"zones/{zoneId}/settings/browser_cache_ttl");

            return client.GetCloudFlareResultAsync<ZoneSetting<int>>(uri, auth, cancellationToken);
        }

        /// <summary>
        /// Browser Integrity Check is similar to Bad Behavior and looks for common HTTP headers abused most commonly
        /// by spammers and denies access to your page.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-browser-check-setting"/>
        public static Task<ZoneSetting<SettingOnOffTypes>> GetBrowserCheckSettingAsync(
            this HttpClient client,
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth)
        {
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            Uri uri = new Uri(CloudFlareConstants.BaseUri, $"zones/{zoneId}/settings/browser_check");

            return client.GetCloudFlareResultAsync<ZoneSetting<SettingOnOffTypes>>(uri, auth, cancellationToken);
        }

        /// <summary>
        /// Cache Level functions based off the setting level.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-cache-level-setting"/>
        public static Task<ZoneSetting<SettingCacheLevelTypes>> GetCacheLevelSettingAsync(
            this HttpClient client,
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth)
        {
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            Uri uri = new Uri(CloudFlareConstants.BaseUri, $"zones/{zoneId}/settings/cache_level");

            return client.GetCloudFlareResultAsync<ZoneSetting<SettingCacheLevelTypes>>(uri, auth, cancellationToken);
        }

        /// <summary>
        /// Specify how long a visitor is allowed access to your site after successfully completing a challenge
        /// (such as a CAPTCHA).
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-challenge-ttl-setting"/>
        public static Task<ZoneSetting<int>> GetChallengeTtlSettingAsync(
            this HttpClient client,
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth)
        {
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            Uri uri = new Uri(CloudFlareConstants.BaseUri, $"zones/{zoneId}/settings/challenge_ttl");

            return client.GetCloudFlareResultAsync<ZoneSetting<int>>(uri, auth, cancellationToken);
        }

        /// <summary>
        /// Development Mode temporarily allows you to enter development mode for your websites if you need to make
        /// changes to your site.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-development-mode-setting"/>
        public static Task<ZoneDevelopmentModeSetting> GetDevelopmentModeSettingAsync(
            this HttpClient client,
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth)
        {
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            Uri uri = new Uri(CloudFlareConstants.BaseUri, $"zones/{zoneId}/settings/development_mode");

            return client.GetCloudFlareResultAsync<ZoneDevelopmentModeSetting>(uri, auth, cancellationToken);
        }

        /// <summary>
        /// Encrypt email addresses on your web page from bots, while keeping them visible to humans.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-email-obfuscation-setting"/>
        public static Task<ZoneSetting<SettingOnOffTypes>> GetEmailObfuscationSettingAsync(
            this HttpClient client,
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth)
        {
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            Uri uri = new Uri(CloudFlareConstants.BaseUri, $"zones/{zoneId}/settings/email_obfuscation");

            return client.GetCloudFlareResultAsync<ZoneSetting<SettingOnOffTypes>>(uri, auth, cancellationToken);
        }

        /// <summary>
        /// When enabled, the Hotlink Protection option ensures that other sites cannot suck up your bandwidth by
        /// building pages that use images hosted on your site.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-hotlink-protection-setting"/>
        public static Task<ZoneSetting<SettingOnOffTypes>> GetHotlinkProtectionSettingAsync(
            this HttpClient client,
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth)
        {
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            Uri uri = new Uri(CloudFlareConstants.BaseUri, $"zones/{zoneId}/settings/hotlink_protection");

            return client.GetCloudFlareResultAsync<ZoneSetting<SettingOnOffTypes>>(uri, auth, cancellationToken);
        }

        /// <summary>
        /// Enable IP Geolocation to have CloudFlare geolocate visitors to your website and pass the country code to
        /// you.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-ip-geolocation-setting"/>
        public static Task<ZoneSetting<SettingOnOffTypes>> GetIpGeolocationSettingAsync(
            this HttpClient client,
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth)
        {
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            Uri uri = new Uri(CloudFlareConstants.BaseUri, $"zones/{zoneId}/settings/ip_geolocation");

            return client.GetCloudFlareResultAsync<ZoneSetting<SettingOnOffTypes>>(uri, auth, cancellationToken);
        }

        private static IEnumerable<ZoneSettingBase> GetZoneSetting(IEnumerable<JObject> jsons)
        {
            if (jsons == null)
                throw new ArgumentNullException(nameof(jsons));

            foreach (JObject json in jsons)
            {
                JToken idToken = json["id"];
                if (idToken == null)
                {
                    throw new InvalidOperationException($"The setting does not have an id property.\n{json}");
                }

                string id = idToken.Value<string>();

                switch (id)
                {
                    case "advanced_ddos":
                    case "always_online":
                    case "browser_check":
                    case "origin_error_page_pass_thru":
                    case "sort_query_string_for_cache":
                    case "email_obfuscation":
                    case "hotlink_protection":
                    case "ip_geolocation":
                    case "mirage":
                    case "prefetch_preload":
                    case "pseudo_ipv4":
                    case "response_buffering":
                    case "server_side_exclude":
                    case "tls_client_auth":
                    case "true_client_ip_header":
                    case "waf":
                    case "tls_1_2_only":
                        yield return json.ToObject<ZoneSetting<SettingOnOffTypes>>();
                        break;
                    case "browser_cache_ttl":
                    case "challenge_ttl":
                    case "edge_cache_ttl":
                    case "max_upload":
                        yield return json.ToObject<ZoneSetting<int>>();
                        break;
                    case "cache_level":
                        yield return json.ToObject<ZoneSetting<SettingCacheLevelTypes>>();
                        break;
                    case "ipv6":
                        yield return json.ToObject<ZoneSetting<SettingIPv6Types>>();
                        break;
                    case "polish":
                        yield return json.ToObject<ZoneSetting<SettingPolishTypes>>();
                        break;
                    case "rocket_loader":
                        yield return json.ToObject<ZoneSetting<SettingRocketLoaderTypes>>();
                        break;
                    case "security_level":
                        yield return json.ToObject<ZoneSetting<SettingSecurityLevelTypes>>();
                        break;
                    case "ssl":
                        yield return json.ToObject<ZoneSetting<SettingSslTypes>>();
                        break;
                    case "development_mode":
                        yield return json.ToObject<ZoneDevelopmentModeSetting>();
                        break;
                    case "minify":
                        yield return json.ToObject<ZoneSetting<SettingMinify>>();
                        break;
                    case "mobile_redirect":
                        yield return json.ToObject<ZoneSetting<SettingMobileRedirect>>();
                        break;
                    case "security_header":
                        yield return json.ToObject<ZoneSetting<SettingSecurityHeader>>();
                        break;
                    default:
                        yield return json.ToObject<ZoneSetting<JToken>>();
                        break;
                }
            }
        }
    }
}
