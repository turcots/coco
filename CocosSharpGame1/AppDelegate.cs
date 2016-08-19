using System.Reflection;
using Microsoft.Xna.Framework;
using CocosSharp;
using CocosDenshion;

namespace CocosSharpGame1
{
    public class AppDelegate : CCApplicationDelegate
    {

        public override void ApplicationDidFinishLaunching(CCApplication application, CCWindow mainWindow)
        {

            //application.PreferMultiSampling = false;
            application.ContentRootDirectory = "Content";
            //application.ContentSearchPaths.Add("animations");
            //application.ContentSearchPaths.Add("fonts");
            //application.ContentSearchPaths.Add("sounds");
            CCSize windowSize = mainWindow.WindowSizeInPixels;

            //var windowSize = mainWindow.WindowSizeInPixels;

            //var desiredWidth = 1024.0f;
            //var desiredHeight = 768.0f;
            var desiredWidth = 311.0f;
            var desiredHeight = 162.0f;

            // This will set the world bounds to be (0,0, w, h)
            // CCSceneResolutionPolicy.ShowAll will ensure that the aspect ratio is preserved
            CCScene.SetDefaultDesignResolution(desiredWidth, desiredHeight, CCSceneResolutionPolicy.ShowAll);
            //  CCScene.SetDefaultDesignResolution(500.0f, 500.0f, CCSceneResolutionPolicy.ShowAll);

            // Determine whether to use the high or low def versions of our images
            // Make sure the default texel to content size ratio is set correctly
            // Of course you're free to have a finer set of image resolutions e.g (ld, hd, super-hd)
            //if (desiredWidth < windowSize.Width)
            //{
            //    application.ContentSearchPaths.Add("hd");
            //    CCSprite.DefaultTexelToContentSizeRatio = 2.0f;
            //}
            //else
            //{
            //    application.ContentSearchPaths.Add("ld");
            //    CCSprite.DefaultTexelToContentSizeRatio = 1.0f;
            //}

            var scene = new CCScene(mainWindow);
            var introLayer = new IntroLayer();

            scene.AddChild(introLayer);

            mainWindow.RunWithScene(scene);
        }

        public override void ApplicationDidEnterBackground(CCApplication application)
        {
            application.Paused = true;
        }

        public override void ApplicationWillEnterForeground(CCApplication application)
        {
            application.Paused = false;
        }
    }
}