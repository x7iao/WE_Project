using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// config 的摘要说明
/// </summary>
public class config
{
    public config()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    // 应用ID,您的APPID
    public static string app_id = "2018052660317019";

    // 支付宝网关
    public static string gatewayUrl = "https://openapi.alipay.com/gateway.do";

    // 商户私钥，您的原始格式RSA私钥
    public static string private_key = "MIIEpQIBAAKCAQEAvBULBrr9r5BlkfRZHQgE3wUO8V0RXAfUQWiV2aCABSUNi/wJZZcC4R2xrjFtoG2fMRh/O2lbFPsiFslkOm8pSuHHUJRUeUwH8h2tM6VDeJJWRz5XxRKwRpJDRfCK62m0pCn6vYObsf6T7Yx6rp8pXcdSk69xcw/g6HtiFtH/HtpRmgL9AzQ2UeRI4/VhxdU64AAlKShF13qW6gSbfyHqxVsAcOJH6JGswSMlxs/i/PJwwLw7n23Me53f9ol6wNVJZTzWAlhseSl5diHdiK8piSmwEOCf/JaZoacaLZj8ByyqwbIJfBM1JZpqBISC2ma++qNiRBp/2K+RMzvv/+yL7QIDAQABAoIBAQC3QsXApBilpUvigDUIXZTpfXNG6MkOZC6EIRTJvWKgIK9nc4fwbckHcjh7o3vO8qFHZDgsuoZeFijsDQVVDpUsenwL3svEeLnRRutJxEDOzb+1oWBCDOinisJz9mJV6WRzBNhlKkRdldGrh9LOLRVQY/PpJOylEZayz+4OkEVGWAK7Sh2EdZoAGTnNi2Mc1oOrGHedNppkiKwnY+aXdcNOJeendp3KBYmG5SI/ZrdaSkRlxJW0fnZZm4ufX/7TZDgZ8xeyJiol3jLzdXBnr9olBPXiv6cpHbfs0s/6cX8WN2Ah6Q61St54BhCvzPbSq6RdUXtbqdVNjVV+9SpH6j29AoGBAPc8zSyyIyVwMia0YmBHaAWDEY8vsKz2i+980+7tSuurQuq4bKR04fGumN0+K/J1Wd7oHcxpM1cwlpxHM34CQwBDhSfUZV+z8hZ1/drBTqtssyxtbdleQFQGCPL6aI36arXCkPEOipRdjsLYfoDZO5HLCKqgcgXM1lH6C3wVdpQrAoGBAMK/hcHTdBn0gUTM0yiWmypEjY7mYz7K9Xl4ukom/+u+N0iJX4xRUgLa5rWTQ6dGIp6SCYksa/kzFEvteew633vz3L2Y0yQy1wQgPSO5UxJBNGIBJcWsXmwFAJcBNzLqM9y0hpydI0Q7Jw81fnhyWQG7p2Yi+EVrTaisgRiVXlxHAoGACdTDG9nhh+WUOPHHT6jHPCDgG997mQUcv2MpUkDhT8m5mXfH6iozqdaVgYatXLDJ6BE2ziAIyJjIBGLYa1RPsbz9mH3bohiXscjzVTWGmU5zOXsIeTJEQJMU3ASVD8A7agrYlJ1NaWTm/lx5e0ooEj4OlCpZHl3sz8mvlzmLQ40CgYEAiQ7XKOkTPa0JSQ1J0rfjreSfJ6HW2PtntTyVBtjZpeSx7ZfYqd0VdbLvSXzB0TiX5rdqhKLBvpkHQMR52Ro57HdctAaZGlG5Z0r1HG4yG5fOMOcT2UGNFkKS/rM5UNjo9PwL/K7OgheLTrXcMxJut7yEfGpCBkEVX49AL7f3t8MCgYEAod+5BaBJHU2Xc5XWEkLk+evtp/0I/osNVwJVagdc1s1UscKkoncB/3y/GmoLzouQ+keBIpCWZUTIMK5czwC0XBRmp7b0n0m3L7JIzZQbqN7cV3L8oDQ7YO3IXQBHFwLlJa2wDIAVzj5KUdWmLLcHTQGFm2yj1sxGnvZnU4cvNjc=";

    // 支付宝公钥,查看地址：https://openhome.alipay.com/platform/keyManage.htm 对应APPID下的支付宝公钥。
    public static string alipay_public_key = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEApFiqHZ+smtNMl4JjgHjToCE+qC9/IphOaeH98oaKQg7tw04AGgYs97k8oreX1YLSBOwif2GOhN7vcKMA/zgnDWAzuetmjhEEhNVEylbGNSXZeD3zz9WdxcqkyDrhS7WrGg8AHgxJFW1Hbt+ULa4UkFySINL//9BFk+Ngexr8PYCMicsfrYqF3bYbOjmnlPyMHrjd0WzOnKQ6WMgvCR9O62ZNIuwYPRom0pUIoZqTg6d17QtUCZKKhHH7iTx8Sdh3VWhgeYWO5IrYBt4ejyuk/KZbeb1pzAw24FnUrKzWeUPfGaoaNDJ0EsGcBNU+YJJZ8zH9IABWRzJ1/CLKWL/mYwIDAQAB";

    // 签名方式
    public static string sign_type = "RSA2";

    // 编码格式
    public static string charset = "UTF-8";
}