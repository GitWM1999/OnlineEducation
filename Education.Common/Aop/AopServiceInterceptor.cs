﻿


using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Education.Common.AOP
{
    public class AopServiceInterceptor : IInterceptor
    {
        #region MyRegion


        ///// <summary>
        ///// 实例化IInterceptor唯一方法
        ///// </summary>
        ///// <param name="invocation">包含拦截方法的信息</param>
        //public void Intercept(IInvocation invocation)
        //{
        //    // 记录被拦截方法的日志信息
        //    var dataInterceptor = $"{DateTime.Now.ToString("yyyyMMddHHmmss")}" +
        //        $"当前执行方法:{invocation.Method.Name} " +
        //        $"参数是: {string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray())} \r\n";
        //    try
        //    {
        //        // 在被拦截的方法执行完毕后 继续执行当前方法
        //        invocation.Proceed();

        //        dataInterceptor += ($"方法执行完毕,返回结果:{invocation.ReturnValue}");

        //        #region 输出当前项目日志
        //        var path = Directory.GetCurrentDirectory() + @"\Log";
        //        if (!Directory.Exists(path))
        //        {
        //            Directory.CreateDirectory(path);
        //        }
        //        string fileName = path + $@"\InterceptLog-{DateTime.Now.ToString("yyyyMMddHHmmss")}.log";
        //        StreamWriter sw = File.AppendText(fileName);
        //        sw.WriteLine(dataInterceptor);
        //        sw.Close();
        //        #endregion
        //    }
        //    catch (Exception e)
        //    {
        //        #region 输出当前项目日志
        //        var path = Directory.GetCurrentDirectory() + @"\Log";
        //        if (!Directory.Exists(path))
        //        {
        //            Directory.CreateDirectory(path);
        //        }
        //        string fileName = path + $@"\InterceptLog-{DateTime.Now.ToString("yyyyMMddHHmmss")}.log";
        //        StreamWriter sw = File.AppendText(fileName);
        //        sw.WriteLine(dataInterceptor + $"方法执行者出现异常：{e.Message + e.InnerException}");
        //        sw.Close();
        //        #endregion
        //        dataInterceptor += ($"方法执行者出现异常：{e.Message + e.InnerException}");
        //    }

        //}
        #endregion


        //////////////////////////////////////////////////////////////////////
        //
        /// <summary>
        /// 日志记录器
        /// </summary>
        // private static readonly ILog Logger = Log.GetLog(typeof(TransactionInterceptor));

        // 是否开发模式
        private bool isDev = false;
        public void Intercept(IInvocation invocation)
        {
            #region 日志


            // 记录被拦截方法的日志信息
            var dataInterceptor = $"{DateTime.Now.ToString("yyyyMMddHHmmss")}" +
                $"当前执行方法:{invocation.Method.Name} " +
                $"参数是: {string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray())} \r\n";
            try
            {
                // 在被拦截的方法执行完毕后 继续执行当前方法
                invocation.Proceed();

                dataInterceptor += ($"方法执行完毕,返回结果:{invocation.ReturnValue}");

                #region 输出当前项目日志
                var path = Directory.GetCurrentDirectory() + @"\Log";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileName = path + $@"\InterceptLog-{DateTime.Now.ToString("yyyyMMddHHmmss")}.log";
                StreamWriter sw = File.AppendText(fileName);
                sw.WriteLine(dataInterceptor);
                sw.Close();
                #endregion
            }
            catch (Exception e)
            {
                #region 输出当前项目日志
                var path = Directory.GetCurrentDirectory() + @"\Log";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileName = path + $@"\InterceptLog-{DateTime.Now.ToString("yyyyMMddHHmmss")}.log";
                StreamWriter sw = File.AppendText(fileName);
                sw.WriteLine(dataInterceptor + $"方法执行者出现异常：{e.Message + e.InnerException}");
                sw.Close();
                #endregion
                dataInterceptor += ($"方法执行者出现异常：{e.Message + e.InnerException}");
            }

            #endregion

            if (!isDev)
            {
                MethodInfo methodInfo = invocation.MethodInvocationTarget;
                if (methodInfo == null)
                {
                    methodInfo = invocation.Method;
                }

                TransactionCallHandlerAttribute transaction =
                    methodInfo.GetCustomAttributes<TransactionCallHandlerAttribute>(true).FirstOrDefault();
                if (transaction != null)
                {
                    TransactionOptions transactionOptions = new TransactionOptions();
                    //设置事务隔离级别
                    transactionOptions.IsolationLevel = transaction.IsolationLevel;
                    //设置事务超时时间为60秒
                    transactionOptions.Timeout = new TimeSpan(0, 0, transaction.Timeout);
                    using (TransactionScope scope = new TransactionScope(transaction.ScopeOption, transactionOptions))
                    {
                        try
                        {
                            //实现事务性工作
                            invocation.Proceed();
                            scope.Complete();
                        }
                        catch (Exception ex)
                        {
                            // 记录异常
                            throw ex;
                        }
                    }
                }
                else
                {
                    // 没有事务时直接执行方法
                    invocation.Proceed();
                }
            }
            else
            {
                // 开发模式直接跳过拦截
                invocation.Proceed();
            }
        }
    }
}
