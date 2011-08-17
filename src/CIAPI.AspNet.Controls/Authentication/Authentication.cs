﻿using System;
using System.ComponentModel;
using System.Web.UI;
using CIAPI.AspNet.Controls.Core;

namespace CIAPI.AspNet.Controls.Authentication
{
	[DefaultProperty("Text")]
	[ToolboxData("<{0}:ServerControl1 runat=server></{0}:ServerControl1>")]
	public class Authentication : WebControlBase
	{
	    private readonly AuthenticationStateChecker _authenticationStateChecker;

        public Authentication()
        {
            UseMockData = false;
            _authenticationStateChecker = new AuthenticationStateChecker(this);
        }

	    protected override void OnPreRender(EventArgs e)
		{
            base.OnPreRender(e);

            CssRegistrar.RegisterFromResource(this, GetType(), "CIAPI.AspNet.Controls.Authentication", "css.ci.default.ci.default.css");
            
            if (IsDebug)
            {
                JavaScriptRegistrar.RegisterFromResource(this, GetType().Assembly, "CIAPI.AspNet.Controls.Authentication", "js.libs.CIAPI.debug.js");
                JavaScriptRegistrar.RegisterFromResource(this, GetType().Assembly, "CIAPI.AspNet.Controls.Authentication", "js.libs.CIAPI.widget.debug.js");
                JavaScriptRegistrar.RegisterFromResource(this, GetType().Assembly, "CIAPI.AspNet.Controls.Authentication", "js.CIAPI.Authentication.debug.js");
            }
            else
            {
                JavaScriptRegistrar.RegisterFromResource(this, GetType().Assembly, "CIAPI.AspNet.Controls.Authentication", "js.libs.CIAPI.min.js");
                JavaScriptRegistrar.RegisterFromResource(this, GetType().Assembly, "CIAPI.AspNet.Controls.Authentication", "js.libs.CIAPI.widget.min.js");
                JavaScriptRegistrar.RegisterFromResource(this, GetType().Assembly, "CIAPI.AspNet.Controls.Authentication", "js.CIAPI.Authentication.min.js");
            }
		    
            if (UseMockData)
            {
                JavaScriptRegistrar.RegisterFromResource(this, GetType().Assembly, "CIAPI.AspNet.Controls.Authentication", "js.CIAPI.amplify.requests.mock.js");
            }
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            var content = ResourceUtil.ReadText(GetType(), "Body.html").ReplaceWebControlTemplateVars(this);
            content = content
                .Replace("{afterLogOn}", GetAfterLogOnScript())
                .Replace("{afterLogOff}", GetAfterLogOffScript());
            output.Write(content);
        }

	    private string GetAfterLogOffScript()
	    {
	        if (!string.IsNullOrEmpty(AfterLogOffNavigateUrl))
	        {
	            return "window.location.href='" + ResolveUrl(AfterLogOffNavigateUrl) + "';";
	        }
	        return "";
	    }

	    
	    private string GetAfterLogOnScript()
	    {
            if (!string.IsNullOrEmpty(AfterLogOnNavigateUrl))
            {
                return "window.location.href='" + ResolveUrl(AfterLogOnNavigateUrl) + "';";
            }
            return ""; 
	    }


	    public bool IsDebug { get; set; }
	    public bool UseMockData { get; set; }
        public string AfterLogOnNavigateUrl { get; set; }
        public string AfterLogOffNavigateUrl { get; set; }

	    public string UserName
	    {
	        get {
                return _authenticationStateChecker.UserName;
	        }
	    }

	    public string Session
        {
            get
            {
                return _authenticationStateChecker.Session;
            }
        }

	    public bool IsAuthenticated
	    {
	        get 
            {
                return _authenticationStateChecker.IsAuthenticated;
	        }
	    }
	}

}