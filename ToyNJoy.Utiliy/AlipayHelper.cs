using System;
using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;

namespace ToyNJoy.Utiliy
{
    public class AlipayHelper
    {
        private AlipayConfig alipayConfig;
        private DefaultAopClient alipayClient;

        public AlipayHelper()
        {
            alipayConfig = new AlipayConfig();
            // AlipayConfig.ServerUrl 默认值是正式环境的地址，这里改成沙箱
            alipayConfig.ServerUrl = "https://openapi.alipaydev.com/gateway.do";
            alipayConfig.AppId = "2016101700709747";
            alipayConfig.PrivateKey = "MIIEowIBAAKCAQEAnojobm27Pk3vlG3nt2XIyXBo2rXLWL7Lftn" +
            "5DNTAEQ++7fJdRUx3qnkaMXKn9TojqamLDMX4SRrth4QNjuqvWdFQCiaRCMbEA4HtBVVefQZoKK+Xgslb" +
            "siczVtW3BGrx9BitTr3IQg0avnOyBE11p+I3xeYLWCwL5TsOM4zmhHi+dyEGLE4iOmyXUjeYqcg4UqcFg" +
            "G24713ypK+zzLgbKZE38Onvo1MIvjMxNQSH1+zeOenjlExU2JZ3l+PaPUURIlY4qC9wurNbLYUO5YGUn4" +
            "OoibNMGEbBA7htbHjdWvhnxqUnmypm3Ano4BLQijIJhHK/kDLUBI4LEHAZNCKYtwIDAQABAoIBAHoedgT" +
            "SbCDTQhCxFIQ2WJOrDmojDY+/8Ns3JtxWadj6qxV505UVETz06lNawbxp25zOp/jf6qDNqFjyRMtpRkfG" +
            "r4QSLzh2e/lDtQOdvhpKvCNTFz+8wfCat7ZVDBTQGK7x71YvZLpUg9xfHKqpzE7VOCcuTGDQFR2v/wGAs" +
            "PUrHAvdWqcymkjMBSW1Wl/lbJRZGCK7wtzM7NYcaaILQ3UTTv5+W4wwAorx51mcBI5xW8p5cDeLKhQdjX" +
            "MHqD1v+z3j5TngbQCPk2Q2RplJA3h/EcvKOikueqMb6rQTqI+DXgMqoZkx2maNvgRE825DW9upWn4XjuI" +
            "AvSGfO1g+WPECgYEA+S3fYMlSXjlYjtmkUdasQGng1wr6wTKLkXqKVfWP/Vlx0uoLJjKurd3HuJVx4ntJ" +
            "FcK4KVSZ4qdHP6yzRqWN36evkGXVRkHozZwkbIStA1FQt0OOKe1k5yh575GUYRW0ELcmi9M+FjKxdm6Fs" +
            "QoxIv6ZfL0s4A6bEZ6G1fmcthkCgYEAot/X3fyMNLnLIJ2PjI4Nnr3hTcsf2ICaxcx5EezQxp18E8PMm2" +
            "moCbSEjQlgr3s1UeqRnKENs2y6d68Kuu2SYmjz1RpzPiCNelrZvb+s7HRQqDoM8eosP685kt1CQ/nz3t1" +
            "ZX42rij2lhghnaVPsGTueO9BcV8fizWBDIE/wf08CgYBEqZJTLkanNjAj9O8lqfz/Ju3Q8/KTCCWTaevy" +
            "sd8ClgIad2mpFfAyctmVEIE4QnaqK2Tp5qkc3rFwZ1tjTT1h8uga5yS03naTKcKTsJ+oOWD/jvr+rK7QT" +
            "8QB8uCrO/rJXF6fyw7huQhTtTLbzQ4rMXMD/3D9MKkkWsWW8thvCQKBgBPcqD5x5ccoQRUhIbhKOm75SN" +
            "hrxN5qEHW+kaUV8//EhLUEU5dAMzW7xc5NLnU32TC8IjWvjjQrNjISLoTNI+TMV6/NIfCZl6csHRF+pl/" +
            "Pb2aUba+yluLNQ4Ada09O0+aBp7x3UkvxaJYHwFSf31LUal9w8VHjFk1lR8pQ9UsRAoGBAOGmeMwEskSc" +
            "/zLYftyiZqdWHHqFMaw14eVSszutreKpIYG0kx/oJErcD0TjsKdedPas8ngMOlH3ZRXNnGCRJ2xh5N36i" +
            "3WpyD/+E6m3ag0L8vzfBCoIhXSeKnparUvtRuSIzXIQP0yEtFCT1Ooi0N+maAz+GGSKpqsXWrHUmk2b";
            alipayConfig.AlipayPublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAuW" +
            "016Sb5e3cd5q6XYnPg60yLKpfxkBHd4xUqPtY1Mt7JMjBbkp0VliFZd1JrecplZfVe3NzTFSkGaqnhZnp" +
            "CgphRTxYUoATJ8+wAJ/mzO/9EJ/vEQxFrZnHdcDV3KQgEJYULdhwtF2nJzMt2ypsmT5943hgwrUlrFIoH" +
            "kHY+90sdelSx82sOlMFABXV0tkciMIAakW7f/2CTg9Gkm2aE7hgjnFJ5nEeNKzoP0OdQVpSqtYEWu/ich" +
            "vGo1SMi4baCL/QYMJLIQx+ZrMasR4wZjIvlthbeBLjnnG67iW+egaJwwtyI5L7mc8JXtzIb+zn4PP181K" +
            "yShYoRicE5+j0hzwIDAQAB";

            alipayClient = new DefaultAopClient(
                alipayConfig.ServerUrl,
                alipayConfig.AppId,
                alipayConfig.PrivateKey,
                alipayConfig.Format,
                "1.0",
                alipayConfig.SignType,
                alipayConfig.AlipayPublicKey,
                alipayConfig.Charset,
                false);
        }

        /// <summary>
        /// 创建支付请求（！！！AdGuard 广告拦截器 会影响沙箱支付宝 使其支付后出现【系统有点忙】错误！！！）
        /// </summary>
        /// <param name="OutTradeNo">订单号</param>
        /// <param name="Subject">订单名</param>
        /// <param name="TotalAmount">金额</param>
        /// <param name="Body">商品描述</param>
        /// <returns></returns>
        public string getPayForm(string OutTradeNo, string Subject, string TotalAmount, string Body)
        {
            AlipayTradePagePayModel payModel = new AlipayTradePagePayModel();
            payModel.OutTradeNo = OutTradeNo;
            payModel.Subject = Subject;
            payModel.TotalAmount = TotalAmount;
            payModel.Body = Body;
            payModel.ProductCode = "FAST_INSTANT_TRADE_PAY";

            AlipayTradePagePayRequest payRequest = new AlipayTradePagePayRequest();

            // 设置同步回调地址
            payRequest.SetReturnUrl("http://localhost:8000/#/PayCallback");

            // 设置异步通知接收地址
            // payRequest.SetNotifyUrl("");?

            // 将业务model载入到request
            payRequest.SetBizModel(payModel);

             AlipayTradePagePayResponse payResponse = alipayClient.pageExecute(payRequest, null, "post");

            return payResponse.Body;
        }
    }
}
