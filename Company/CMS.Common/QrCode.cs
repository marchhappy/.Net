using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using ThoughtWorks.QRCode.Codec.Util;
using System.Drawing;

namespace CMS.Common
{
    public class QrCode
    {
        /// <summary>
        /// 生成二维码（返回Image）用于使用
        /// </summary>
        /// <param name="bulidValue"></param>
        /// <param name="errorCorrect"></param>
        /// <param name="codeScale"></param>
        /// <param name="codeVersion"></param>
        /// <returns></returns>
        public static Image BuildCode(string bulidValue, int errorCorrect = 2, int codeScale = 4, int codeVersion = 7)
        {
            try
            {
                if (bulidValue.Trim() == String.Empty)
                {
                    return null;
                }
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeScale = codeScale;
                qrCodeEncoder.QRCodeVersion = codeVersion;
                if (errorCorrect == 1)
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                else if (errorCorrect == 2)
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                else if (errorCorrect == 3)
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
                else if (errorCorrect == 4)
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
                else
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                return qrCodeEncoder.Encode(bulidValue);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 通过Image识别二维码
        /// </summary>
        /// <param name="imageValue"></param>
        /// <returns></returns>
        public static string ReadCode(Image imageValue)
        {
            try
            {
                QRCodeDecoder decoder = new QRCodeDecoder();
                return decoder.decode(new QRCodeBitmapImage(new Bitmap(imageValue)));
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 通过文件识别二维码
        /// </summary>
        /// <param name="imageValue"></param>
        /// <returns></returns>
        public static string ReadCode(string fileName)
        {
            try
            {
                QRCodeDecoder decoder = new QRCodeDecoder();
                if (fileName.EndsWith(".jpg") || fileName.EndsWith(".bmp") || fileName.EndsWith(".jpeg") || fileName.EndsWith(".png"))
                    return decoder.decode(new QRCodeBitmapImage(new Bitmap(fileName)));
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
