using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingTask.Utils
{
    internal class XpathPatterns
    {
        public static readonly string preciseTextXpath = "//*[text()='{0}']";
        public static readonly string dynamicControl = "//a[@href='/dynamic_controls']";
        public static readonly string enableBtn1 = "(//*[@type='button'])[2]";
        public static readonly string inputField1 = "//input[@type='text']";
        public static readonly string framesBtn1 = "//*[@href='/frames']";
        public static readonly string iframeBtn1 = "//a[@href='/iframe']";
        public static readonly string undoBtn1 = "//div[@class='tox-collection__item-label'])[1]";
        public static readonly string editBtn1 = "//button[@class='tox-mbtn tox-mbtn--select'])[2]";
        public static readonly string textField1 = "id='tinymce'";
        public static readonly string fileBtn = "(//*[@class='tox-mbtn__select-label'])[1]";
        public static readonly string newPage = "//*[@class='tox-collection__item-label']";
    }
}
