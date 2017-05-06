using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Net.Configuration;

namespace AccuWeather
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		[Test]
		public void AppLaunches()
		{
			app.Repl();
		}

		[Test]
		public void FirstTest()
		{
			app.Tap("button1");
			app.Screenshot("Let's start by Tapping on the 'Agree' Button");
			app.Tap(x => x.Class("android.widget.ImageButton").Index(0));

			app.Screenshot("Then we Tapped the 'Hamburger' Button");
			app.Tap("search_text");
			app.Screenshot("Next we Tapped on the 'Search Text' Field");
			app.EnterText("San Francisco");
			app.Screenshot("We entered our search, 'San Francisco'");
			app.PressEnter();
			app.Screenshot("Then we Tapped 'Enter' on the keyobard");

			app.Tap(x => x.Class("android.widget.RelativeLayout").Index(1));
			app.Screenshot("We Tapped on the first result, 'San Francisco'");

		}

	}
}
