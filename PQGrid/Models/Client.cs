using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PQGrid.Models
{
    public class Client
    {
        /// <summary>
        /// ID键值
        /// </summary>
        public string ID { set; get; }

        /// <summary>
        /// 客户手机号
        /// </summary>
        public string Mobile { set; get; }

        /// <summary>
        /// 客户微信OpenID
        /// </summary>
        public string OpenID { get; set; }

        /// <summary>
        /// 邀请码GUID
        /// 之所以同时存在InviteCode和InviteCodeID，是为了在客户修改邀请码时候修改之前已经分享出去的邀请链接依然能找到对应邀请人
        /// </summary>
        public string InviteCodeID { get; set; }

        /// <summary>
        /// 邀请码
        /// </summary>
        public string InviteCode { get; set; }

        /// <summary>
        /// 邀请人码
        /// </summary>
        public string InvitedCode { get; set; }

        /// <summary>
        /// 邀请总数
        /// </summary>
        public int InvitingTotal { get; set; }

        /// <summary>
        /// 当月邀请人数
        /// </summary>
        public int CurrentMonthInviting { get; set; }

        /// <summary>
        /// 促成借款邀请数目
        /// </summary>
        public int DealedInviting { get; set; }

        /// <summary>
        /// QQ号
        /// </summary>
        public string QQ { get; set; }

        /// <summary>
        /// 微信号
        /// </summary>
        public string WeChat { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// 最后认证身份证时间
        /// </summary>
        public DateTime? LastIdentifyIDTime { get; set; }

        /// <summary>
        /// 身份验证输错次数，超过两次自动要求验证全部身份证号
        /// </summary>
        public int IdentifyErrorTry { get; set; }
    }

    public class CilentMapper : ClassMapper<Client>
    {
        public CilentMapper()
        {
            Table("expand_client");
            Map(t => t.ID).Key(KeyType.Assigned);
            AutoMap();
        }
    }
}