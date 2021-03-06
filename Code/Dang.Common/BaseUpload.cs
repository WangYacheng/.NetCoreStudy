using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Dang.Common
{
    public class BaseUpload
    {
        //图片大小KB
        const int imageSize = 10240;
        //附件大小KB
        const int attachSize = 51200;

        /// <summary>
        /// 是否为图片文件
        /// </summary>
        /// <param name="_fileExt">文件扩展名，不含“.”</param>
        public bool IsImage(string _fileExt)
        {
            var al = new ArrayList();
            al.Add("bmp");
            al.Add("jpeg");
            al.Add("jpg");
            al.Add("gif");
            al.Add("png");
            if (al.Contains(_fileExt.ToLower()))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 检查是否为合法的上传文件
        /// </summary>
        public bool CheckFileExt(string _fileExt)
        {
            //检查危险文件
            string[] excExt = { "asp", "aspx", "ashx", "asa", "asmx", "asax", "php", "jsp", "htm", "html" };
            for (int i = 0; i < excExt.Length; i++)
            {
                if (excExt[i].ToLower() == _fileExt.ToLower())
                {
                    return false;
                }
            }
            //检查合法文件
            string[] allowExt = ("jpg,png,bmp,jpeg,gif,amr,mp3,wav,mp4").Split(',');
            for (int i = 0; i < allowExt.Length; i++)
            {
                if (allowExt[i].ToLower() == _fileExt.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 检查文件大小是否合法
        /// </summary>
        /// <param name="_fileExt">文件扩展名，不含“.”</param>
        /// <param name="_fileSize">文件大小(B)</param>
        public bool CheckFileSize(string _fileExt, long _fileSize)
        {
            //判断是否为图片文件
            if (IsImage(_fileExt))
            {
                if (imageSize > 0 && _fileSize > imageSize * 1024)
                {
                    return false;
                }
            }
            else
            {
                if (attachSize > 0 && _fileSize > attachSize * 1024)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
