using System;
using System.Collections.Generic;
using Abp.Domain.Entities;
using Abp.Web.Models;
using Cloud.Framework.Assembly;
using Cloud.Framework.Mongo;
using Newtonsoft.Json.Linq;

namespace Cloud.Domain
{
    public class TestManager
    {

        /// <summary>
        /// 参数列表
        /// </summary>
        public Dictionary<string, string> Parament { get; set; }

        /// <summary>
        /// 请求方式
        /// </summary>
        public string CallType { get; set; }

        /// <summary>
        /// 测试环境
        /// </summary>
    //    public TestEnvironment TestEnvironment { set; get; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public string DateType { get; set; }

        /// <summary>
        /// 链接类型
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// 是否需要登陆
        /// </summary>
        public bool IsLogin { get; set; }

        /// <summary>
        /// 调用状态
        /// </summary>
        public bool CallState { get; set; } = true;

        /// <summary>
        /// 返回结果集
        /// </summary>
        public AjaxResponse<dynamic> Result { get; set; }

        /// <summary>
        /// 耗时
        /// </summary>
        public long Take { get; set; }

        /// <summary>
        /// 调用时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 调用者
        /// </summary>
        public long? UserId { get; set; }

        /// <summary>
        /// 测试类型
        /// </summary>
        public TestType TestType { get; set; }
    }

    public enum TestType
    {
        /// <summary>
        /// 自动测试,对结果集直接赋值调用
        /// </summary>
        Auto,
        /// <summary>
        /// 用户调用接口时记录
        /// </summary>
        User,
        /// <summary>
        /// 定时器,定时调用
        /// </summary>
        Timer,
        /// <summary>
        /// 系统调用,系统按需测试
        /// </summary>
        System

    }
}