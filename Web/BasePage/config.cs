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
    public static string private_key = "MIIEogIBAAKCAQEAsSkemKPysOY4y8VTeRdRVhAHYj3JaZVE3xEBTBaaRM95phO8NIEKtA4jH3tVj5NyuOESjvgGz/MyJFdNXd9HsLpLHmpwsPu47fa5U7D2HlV6Zj4Rt3r279Q9IWEyJN+6YQl9CVqlfkcRnG4yken3kQcb1iEWci3T+KXC1TS2GhAKfXYqirW0XXqDiroWR153SUL3XX3x8B+bOM/X/5QXDgnycGh7NDgq3CPiYZvTf5mKiswcAfuaW4WURB2B6QnaQV74dXda73K6JBhKG5OGSZjdkLynpP9TPgSQNQn7IT4E3P+yMPgE0INoSEiPq9QLr+SAo/HvXXHpxcP/qLE2GQIDAQABAoIBAE0BqaoBwbFBMTjp2gHNr+4v43XBk7YQSzKHCsBPJtl4MdGNzIYp/UQMzRmXG7bgCcLxGocIqrVjac1AIYIHVvsrzxE2hSt5D4Zoc2A8kI7Y6u5cVokhqwrOf4/t1sUOds5NOIuDWmJMdAxCHjssrw7cPy5RjZct8nCnZMwWMH2c+BBz9YEkBdKbURHm50Za5Cz6npEPlCzoUe6X/MpnUlacfaFgxYe23IwZPvOjRvQwj49wjmev/oqd37oRcp2QKkr+mOogtUrf6Z5+QUPqI1tXkT5xue0saHdu6psTPTH4zdTjvB56Tub8refibhoxufYm0emNEy7vTdWNjjupfP0CgYEA3o7jHrKCM+j1N0oH6Sq9FLXK6gzAtEpDPAMRCl03QryoA/h99e7EwpC8veLmeBL9J9Gn2MkDE2j0zxqBGjH9QKkNv5Xp2WfPV9edm4M0LEpngvSiXj4Trx8Bh3KO6Td8is5Vq7LddLK8S7ZoJWQntgwkSWGtKEk41kNgjQjoVgsCgYEAy8ful7p1vfQXs2Oy6VnTzcltExQh8SixDuOOFWyfO7xcK0Exf0p2N8R7CdCeawnoK+e8Y22cRzEAF6/FCUQod/T17bZRHM/xM/8R9r8p7trVeFrsaDMp9QUAVoCg79faxEetw4FBE28noM+X4DR2Ip12U+wyD6CbRj1eQ7HE7usCgYBQLXXRB0o03UYKJxd2frkjjuKNMw7xZJeYNRqcezx/RGvbElh+kwg7d90nI2kX9O9SuwsW5EPBaFxZiBjekQfFlaGoVZ+rfOSLptfWwIu5MQzddrhP71k0C52HaFPn3N93OiJO+t8hPYrsU8htQAm2YeVoslGpY8egGSHdbUoWRQKBgGkhzbsjrGkCjFO1ZPE0sawidg54vYYgWzB2P7BX6NK1u8tpB/NG5DSjPmLy6TgJ1WkJVkzpmM21vvl5air8qfAxRcuM2s4FjcgomQj22Nhst+Mu7XZYpxXMrb7y/5SdhTTsUf5iKcOv/f7d+tnl1ujG2ew0GCOt1U3ojUBZb2NfAoGAFxcPc39pVo0mAkWkv4RCgiw5kL/Q05phR4BuY79tjM1OUVO1EzAdWsACq/GmoKAQdnm/fYH2yqQ9hLXM/pY46DoV1suBtt9tR9GiJioTSfEEXT+OcHpqfip584g0wxyWZQ6mOzLuJgf+fkOCPkV6+c9y57fCtiYQ6mfQzylsajQ=";

    // 支付宝公钥,查看地址：https://openhome.alipay.com/platform/keyManage.htm 对应APPID下的支付宝公钥。
    public static string alipay_public_key = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAuhuvj1j+4CafkDdTdG1OmISxQntAybLCF08zX7fD6vLrAj57gH4I86bOUQsboei27DsiN1DuvJx6g48EZ3eIC8ERyscaAkiWuEBM1S2i+/nLg5zgZc4kWpvqElCdO4OTOLCSnc7wpNplKxVPjmKouvhCn7pLBoA90DzS/Am2XTQFiz8+oR7wWaOkuEVc94egxDTCxj+WpzzrR9JA91Nr/FsowqINvXAGLhuyp4S+8q1dW1rYvt3VeJtA3YBW0HBikuZiQFIGnrHFhpRq0CAOOIU8fGxEvLcaDTYIWOx4aywnzaGd3CtEwZ9vhs9kbBGutHRXSJf4ZWH1Z+KoXI8vtwIDAQAB";

    // 签名方式
    public static string sign_type = "RSA2";

    // 编码格式
    public static string charset = "UTF-8";
}