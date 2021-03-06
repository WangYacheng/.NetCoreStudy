
using Aliyun.OSS;
using Aliyun.OSS.Common;
using Dang.Common;
using JLSys.Common.Aliyun;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Dang.Common.Aliyun
{
    public class OssUpload : BaseUpload
    {
        private readonly OssSetting _config;
        private readonly ILogger<OssUpload> _logger;
        private readonly string upLoadPath = string.Empty;


        public OssUpload(OssSetting config)
        {
            _config = config;
            _logger = (ILogger<OssUpload>)Dang.Common.MyServiceProvider.ServiceProvider.GetService(typeof(ILogger<OssUpload>));
            upLoadPath = $"/upload/{DateTime.Now.ToString("yyyyMM")}/{DateTime.Now.ToString("dd")}/";

        }

        #region 函数定义

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="key">文件标识</param>
        /// <param name="file">需要上传文件的文件路径</param>
        public bool PutObject(string key, string file)
        {
            var client = new OssClient(_config.endpoint, _config.accessKeyId, _config.accessKeySecret);
            try
            {
                client.PutObject(_config.bucketName, key, file);
                return true;
            }
            catch (OssException ex)
            {
                _logger.LogError($"Msg:{ex.Message};Code:{ex.ErrorCode};RequestID:{ex.RequestId};HostID:{ex.HostId}", ex);
                return false;
            }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="key">文件标识</param>
        /// <param name="file">需要上传文件的文件路径</param>
        public PutObjectResult PutObject(string key, Stream stream)
        {
            var client = new OssClient(_config.endpoint, _config.accessKeyId, _config.accessKeySecret);
            try
            {
                var res = client.PutObject(_config.bucketName, key, stream);
                return res;
            }
            catch (OssException ex)
            {
                _logger.LogError($"Msg:{ex.Message};Code:{ex.ErrorCode};RequestID:{ex.RequestId};HostID:{ex.HostId}", ex);
                return null;
            }
        }


        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="key">文件标识</param>
        /// <param name="file">需要上传文件的文件路径</param>
        public PutObjectResult PutObject(string key, byte[] byteData)
        {
            try
            {
                var stream = Utils.BytesToStream(byteData);
                return PutObject(key, stream);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Msg:{ex.Message}", ex);
                return null;
            }
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="key">文件标识</param>
        /// <param name="file">下载存放的文件路径</param>
        public bool GetObject(string key, string file)
        {
            var client = new OssClient(_config.endpoint, _config.accessKeyId, _config.accessKeySecret);
            try
            {
                var result = client.GetObject(_config.bucketName, key);
                using (var requestStream = result.Content)
                {
                    using (var fs = File.Open(file, FileMode.OpenOrCreate))
                    {
                        int length = 4 * 1024;
                        var buf = new byte[length];
                        do
                        {
                            length = requestStream.Read(buf, 0, length);
                            fs.Write(buf, 0, length);
                        } while (length != 0);
                    }
                }
                return true;
            }
            catch (OssException ex)
            {
                _logger.LogError($"Msg:{ex.Message};Code:{ex.ErrorCode};RequestID:{ex.RequestId};HostID:{ex.HostId}", ex);
                return false;
            }
        }

        /// <summary>
        /// 获取图片地址
        /// </summary>
        /// <param name="key">文件标识</param>
        /// <param name="width">设置图片的宽度</param>
        /// <param name="height">设置图片的高度</param>
        /// <returns></returns>
        public string GetImageUrl(string key, float width = 100, float height = 100)
        {
            var client = new OssClient(_config.endpoint, _config.accessKeyId, _config.accessKeySecret);
            try
            {
                var process = $"image/resize,m_fixed,w_{width},h_{height}";
                client.SetBucketAcl(_config.bucketName, CannedAccessControlList.PublicRead);
                var req = new GeneratePresignedUriRequest(_config.bucketName, key, SignHttpMethod.Get)
                {
                    Expiration = DateTime.Now.AddYears(2),
                    Process = process
                };
                var uri = client.GeneratePresignedUri(req);
                //client.GeneratePresignedUri()
                var url = uri.ToString();
                var index = url.IndexOf("?");
                if (index > 0)
                {
                    url = url.Substring(0, index).Replace("?", "");
                }
                return url;
            }
            catch (OssException ex)
            {
                _logger.LogError($"Msg:{ex.Message};Code:{ex.ErrorCode};RequestID:{ex.RequestId};HostID:{ex.HostId}", ex);
            }
            return "";
        }

        /// <summary>
        /// 获取图片地址
        /// </summary>
        /// <param name="key">文件标识</param>
        /// <param name="width">设置图片的宽度</param>
        /// <param name="height">设置图片的高度</param>
        /// <returns></returns>
        public string GetFileUrl(string key)
        {
            var client = new OssClient(_config.endpoint, _config.accessKeyId, _config.accessKeySecret);
            try
            {
                client.SetBucketAcl(_config.bucketName, CannedAccessControlList.PublicRead);
                //var req = new GeneratePresignedUriRequest(_config.bucketName, key, SignHttpMethod.Get);
                var uri = client.GeneratePresignedUri(_config.bucketName, key, SignHttpMethod.Get);
                var url = uri.ToString();
                var index = url.IndexOf("?");
                if (index > 0)
                {
                    url = url.Substring(0, index).Replace("?", "");
                }
                return url;
            }
            catch (OssException ex)
            {
                _logger.LogError($"Msg:{ex.Message};Code:{ex.ErrorCode};RequestID:{ex.RequestId};HostID:{ex.HostId}", ex);
            }
            return "";
        }

        #endregion

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="originalFilePath">文件服务器</param>
        /// <param name="_fileExt"></param>
        /// <returns></returns>
        public (bool result, string NewFilePath, string ThumbFilePath, string FileName, string Message)
            fileSaveAs(string originalFilePath, string _fileExt, bool _isThumb = false)
        {
            try
            {
                var file = new System.IO.FileInfo(originalFilePath);
                long fileSize = file.Length; //获得文件大小，以字节为单位
                //检查文件扩展名是否合法
                if (!CheckFileExt(_fileExt))
                {
                    return (false, string.Empty, string.Empty, string.Empty, "不允许上传" + _fileExt + "类型的文件！");
                }
                //检查文件大小是否合法
                if (!CheckFileSize(_fileExt, fileSize))
                {
                    return (false, string.Empty, string.Empty, string.Empty, "文件超过限制的大小！");
                }
                //获取文件流
                FileStream fsRead = file.OpenRead();
                var result = fileSaveAs(fsRead, _fileExt, _isThumb);
                if (result.result)
                {
                    return result;
                }
                else
                {
                    //如果单次上传失败，重试5次
                    for (int i = 0; i < 5; i++)
                    {
                        result = fileSaveAs(fsRead, _fileExt, _isThumb);
                        if (result.result)
                            return result;
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("保存上传图片错误", ex);
                return (false, string.Empty, string.Empty, string.Empty, "上传过程中发生意外错误！");
            }
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="_fileExtName"></param>
        /// <returns></returns>
        public (bool result, string NewFilePath, string ThumbFilePath, string FileName, string Message)
            fileSaveAs(Stream stream, string _fileExt, bool _isThumb = false)
        {
            try
            {
                //生成存储的文件名
                var guid = Guid.NewGuid().ToString();
                string fileKey = upLoadPath + guid;
                string _fileName = fileKey.Trim('/') + "." + _fileExt;
                //重命名文件加上时间戳
                var uploadRes = PutObject(_fileName, stream);
                if (uploadRes != null && uploadRes.HttpStatusCode == HttpStatusCode.OK)
                {
                    var webFileName = GetFileUrl(_fileName);
                    var webThumbFileName = "";
                    if (_isThumb)
                    {
                        webThumbFileName = GetImageUrl(_fileName, 300, 300);
                    }
                    return (true, webFileName, webThumbFileName, _fileName, "文件上传成功");
                }
                else
                {
                    _logger.LogTrace("上传失败信息");
                    return (false, string.Empty, string.Empty, string.Empty, uploadRes.ETag);
                }
            }
            catch (Exception ex)
            {
                _logger.LogTrace("保存上传文件错误", ex);
                return (false, string.Empty, string.Empty, string.Empty, "上传过程中发生意外错误！");
            }
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="_fileExtName"></param>
        /// <returns></returns>
        public (bool result, string NewFilePath, string ThumbFilePath, string FileName, string Message)
            fileSaveAs(byte[] byteData, string _fileExt, bool _isThumb = false)
        {

            try
            {
                //生成存储的文件名
                var guid = Guid.NewGuid().ToString();
                string fileKey = upLoadPath + "/" + guid;
                string _fileName = fileKey.Trim('/') + "." + _fileExt;

                var uploadRes = PutObject(_fileName, byteData);
                if (uploadRes != null && uploadRes.HttpStatusCode == HttpStatusCode.OK)
                {
                    var webFileName = GetFileUrl(_fileName);
                    var webThumbFileName = "";
                    if (_isThumb)
                    {
                        webThumbFileName = GetImageUrl(_fileName, 300, 300);
                    }
                    return (true, webFileName, webThumbFileName, _fileName, "文件上传成功");
                }
                else
                {
                    _logger.LogTrace("上传失败信息");
                    return (false, string.Empty, string.Empty, string.Empty, uploadRes.ETag);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("保存上传图片错误", ex);
                return (false, string.Empty, string.Empty, string.Empty, "上传过程中发生意外错误！");
            }
        }

    }
}
