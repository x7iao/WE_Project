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
    public static string app_id = "2018040502507600";

    // 支付宝网关
    public static string gatewayUrl = "https://openapi.alipay.com/gateway.do";

    // 商户私钥，您的原始格式RSA私钥
    public static string private_key = "MIIEpAIBAAKCAQEAqmJXV7QNugFnk8PDj3RMM9m4YhIeCUf3mSn3g4qGjsIkjQ/fh8fV4Jqj5CnUsHOf99YRXpTJnkST3g8OffWqjtQ/uWn5uX22PW2ZhPuI99dvlsUyNDtX6KLoqRiDbtWIORgNL/M5DXbct0hqkvWQ89VBTTvtKDh0YELrVVUz2wstrcJc4jsFhbvC3QFrnbfIyM3pLOfAPW8HHOr1SNra628skBAZ7dpPAP6pCTZKHpiFA15edXI2VVuWgKwh1C32tNT8uqRI6VeLa3nqiCkt9tmQcd4ACF7bHi5etUTewl42IZmjdFKMp0kBRjuvrmU5zC2m0brNOv5CTd8ucLqnUwIDAQABAoIBADcVEc2NrP5cI+MWX6uJ2nTMxxoVZ1ZyyK3gbl89MmEGjJB5+DbKOO+irqc9ir/8sVOLBhSAn2mmG/OnBHVeLWR9Y5iKlSwNYxQa0Y23T8FoCXBBkghmwvW3bOX1wc/cAm0KxICi7efXbGVoaOPXtaPOZo0UeYgOMDlKiRAOOnRucmaPp+ixifyPk7l1cBg/TUFlNx9FT6DofrGkjNdHwLnHfXxX9tJVwb2lmsBb96SS82qlVj6DvliPtMrwjAZiRiuAYvGcp4fmyzseX0GWWJ49gritiJPsvT4+Dn5lYxLpb3ySnPfQKIV+zu2aIorXIpr7Dt4AiaUuoSTc/1pXtYECgYEA3qhnbkCrv6jNqJn+Yp3RG4s3uYdAvFpmNQTODjv2iv927GXz+Po1E+sCmxX89X4TSCycG7B6Ja5WvoJDLr4XFIGpRDrApNMIQqcaMvU534pmp8qY6v+MtsqZIpgqnXoczbw2gFmyjxcyQqa9Mwn8meLLshEjQweTrEd2EB+fXEECgYEAw+YGC1Le2siHAgwX2/6jwXJiFy96AfaI5FZyDo0k+s2zEqyo8+QcqDatO6j6YPUFXVjC82xEywPc90fYeZgAO8wSquHWgVFnNO2U0RsHcglwr56zM9QDzO5ltDZI46X9A41eSQ0aShNp5+3vdceJmwRFZ/MkT0apO1lhzkBlLpMCgYAkh3xwmiuTRh53iswxYbLs0epShd4ZCLu79w3XR/8qzr60CgX80w/iNKw4xWK64/RF4wu5fzqK9A9HMhfTk1w2AQ/EId95KyYvyTqDIbhc9FfjL1nnNAXh91soUc6sB1yyZC6M4CprT2LvjGt99CV9GbhRfn5KgPO5UAAOpSGAAQKBgQC0ydoWJTqp6po+F28FhnEWHDvObfBJU35uTCEisLvKAoAa4eFig8i2rQ8emgnH5Rg4V6xC/k5WlZAdXd64CMFebi1kKtvNqJR40jGe8TTj1zZ5vRpg4G9Jd1HBCMAn544i8xpqjH8Qke4RLxLpPWcO+tga4NdHmkygCxMqR1+ZpQKBgQDZsqTYiAL64uv63xqD4vioWx7jZfm96Nsz9jMv0UHNvmH2benE/OWBYdjlyIDTxwiIqV6xekm7lWxnMPSyB2TlM0xFYWQYHHpLNm+WlVwSVGSoqGeow033vsf4Sve5yhIhY5JNDkvps1VxqvEcuLc9r7wyjUCajwJ6tw/Gm/hN1A==";

    // 支付宝公钥,查看地址：https://openhome.alipay.com/platform/keyManage.htm 对应APPID下的支付宝公钥。
    public static string alipay_public_key = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEApFiqHZ+smtNMl4JjgHjToCE+qC9/IphOaeH98oaKQg7tw04AGgYs97k8oreX1YLSBOwif2GOhN7vcKMA/zgnDWAzuetmjhEEhNVEylbGNSXZeD3zz9WdxcqkyDrhS7WrGg8AHgxJFW1Hbt+ULa4UkFySINL//9BFk+Ngexr8PYCMicsfrYqF3bYbOjmnlPyMHrjd0WzOnKQ6WMgvCR9O62ZNIuwYPRom0pUIoZqTg6d17QtUCZKKhHH7iTx8Sdh3VWhgeYWO5IrYBt4ejyuk/KZbeb1pzAw24FnUrKzWeUPfGaoaNDJ0EsGcBNU+YJJZ8zH9IABWRzJ1/CLKWL/mYwIDAQAB";

    // 签名方式
    public static string sign_type = "RSA2";

    // 编码格式
    public static string charset = "UTF-8";
}