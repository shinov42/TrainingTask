using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Utils
{
    internal class XpathPatterns
    {
        public static readonly string preciseTextXpath = "//*[text()='{0}']";
        public static readonly string dynamicControl = "//a[@href='/dynamic_controls']";
        public static readonly string enableBtn = "//button[@onclick='swapInput()']";
        public static readonly string inputField = "id='input-example'";
        public static readonly string framesBtn = "//*[@href='/frames']";
        public static readonly string iframeBtn = "//a[@href='/iframe']";
        public static readonly string undoBtn = "//div[@class='tox-collection__item-label'])[1]";
        public static readonly string editBtn = "//button[@class='tox-mbtn tox-mbtn--select'])[2]";
        public static readonly string textField = "id='tinymce'";

    }
}
