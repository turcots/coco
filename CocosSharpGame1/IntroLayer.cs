using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;

namespace CocosSharpGame1
{
    public class IntroLayer : CCLayerColor
    {

        // Define a label variable
        //CCLabel label;
        CCSprite spBackground;
        CCSprite spPlane;
        CCSprite spPlaneDestination;
        CCPoint destination;
        float destinationX;
        float destinationY;

        float distanceX;
        float distanceY;

        readonly CCNode drawNodeRoot;

        //float desiredWidth = 1024.0f;
        //float desiredHeight = 768.0f;
        //CCSpriteFrame spriteFrame;

        public IntroLayer() : base(CCColor4B.Blue)
        {
            drawNodeRoot = new CCNode()
            {
                PositionX = 85.0f,
                PositionY = 60.0f
            };



            // create and initialize a Label
            //label = new CCLabel("Hello CocosSharp", "fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont);

            //// add the label as a child to this Layer
            //AddChild(label);

            spBackground = new CCSprite("map");
            ResizeSpriteToScreen(spBackground);
            AddChild(spBackground);

            spPlane = new CCSprite("plane");
            spPlane.IsAntialiased = false;
            spPlane.ContentSize = spPlane.ContentSize / 10;
            //spPlane.PositionX = 85.0f;
            //spPlane.PositionY = 60.0f;
            //AddChild(spPlane);
            drawNodeRoot.AddChild(spPlane);

            destinationX = 250.0f;
            destinationY = 100.0f;

            destination = new CCPoint(destinationX / 2, destinationY / 2);

            //distanceX = destinationX - spPlane.PositionX;
            //distanceY = destinationY - spPlane.PositionY;
            AddChild(drawNodeRoot);

            //spPlaneDestination = new CCSprite("plane");
            //spPlaneDestination.ContentSize = spPlaneDestination.ContentSize / 10;
            //spPlaneDestination.PositionX = 250.0f;
            //spPlaneDestination.PositionY = 100.0f;
            //AddChild(spPlaneDestination);


            //spPlane.
            //ResizeSpriteToScreen(spPlane);
        }

        public void ResizeSpriteToScreen(CCSprite sprite)
        {
            sprite.PositionX = spBackground.ContentSize.Width / 2;
            sprite.PositionY = spBackground.ContentSize.Height / 2;
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();

            // Use the bounds to layout the positioning of our drawable assets
            //var bounds = VisibleBoundsWorldspace;

            //// position the label on the center of the screen
            //label.Position = bounds.Center;

            // Register for touch events
            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesEnded = OnTouchesEnded;
            AddEventListener(touchListener, this);
        }

        void OnTouchesEnded(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (touches.Count > 0)
            {
                // Perform touch handling here
                var touch = touches[0];

                HandleMoveCircle(touch);

            }
        }

        void HandleMoveCircle (CCTouch touch){
            const float timeToTake = 1.5f; // in seconds

            CCFiniteTimeAction coreAction = null;

            // By default all actions will be added directly to the
            // root node - it has values for Position, Scale, and Rotation.
            CCNode nodeToAddTo = drawNodeRoot;

            coreAction = new CCMoveTo(timeToTake, touch.Location);
           //  coreAction = new CCMoveTo(timeToTake, destination);

            //switch (VariableOptions[currentVariableIndex])
            //{
            //    case "Position":
            //        coreAction = new CCMoveTo(timeToTake, touch.Location);
            //        break;
            //    case "Scale":
            //        var distance = CCPoint.Distance(touch.Location, drawNodeRoot.Position);
            //        var desiredScale = distance / DefaultCircleRadius;
            //        coreAction = new CCScaleTo(timeToTake, desiredScale);
            //        break;
            //    case "Rotation":
            //        float differenceY = touch.Location.Y - drawNodeRoot.PositionY;
            //        float differenceX = touch.Location.X - drawNodeRoot.PositionX;

            //        float angleInDegrees = -1 * CCMathHelper.ToDegrees(
            //            (float)Math.Atan2(differenceY, differenceX));

            //        coreAction = new CCRotateTo(timeToTake, angleInDegrees);

            //        break;
            //    case "LineWidth":
            //        coreAction = new LineWidthAction(timeToTake, touch.Location.X / 40f);
            //        // The LineWidthAction is a special action designed to work only on
            //        // LineNode instances, so we have to set the nodeToAddTo to the lineNode:
            //        nodeToAddTo = lineNode;
            //        break;
            //}

            //CCAction easing = null;
            //switch (EasingOptions[currentEasingIndex])
            //{
            //    case "CCEaseBack":
            //        if (currentInOutIndex == 0)
            //            easing = new CCEaseBackOut(coreAction);
            //        else if (currentInOutIndex == 1)
            //            easing = new CCEaseBackIn(coreAction);
            //        else
            //            easing = new CCEaseBackInOut(coreAction);

            //        break;
            //    case "CCEaseBounce":
            //        if (currentInOutIndex == 0)
            //            easing = new CCEaseBounceOut(coreAction);
            //        else if (currentInOutIndex == 1)
            //            easing = new CCEaseBounceIn(coreAction);
            //        else
            //            easing = new CCEaseBounceInOut(coreAction);

            //        break;
            //    case "CCEaseElastic":
            //        if (currentInOutIndex == 0)
            //            easing = new CCEaseElasticOut(coreAction);
            //        else if (currentInOutIndex == 1)
            //            easing = new CCEaseElasticIn(coreAction);
            //        else
            //            easing = new CCEaseElasticInOut(coreAction);

            //        break;
            //    case "CCEaseExponential":
            //        if (currentInOutIndex == 0)
            //            easing = new CCEaseExponentialOut(coreAction);
            //        else if (currentInOutIndex == 1)
            //            easing = new CCEaseExponentialIn(coreAction);
            //        else
            //            easing = new CCEaseExponentialInOut(coreAction);

            //        break;
            //    case "CCEaseSine":
            //        if (currentInOutIndex == 0)
            //            easing = new CCEaseSineOut(coreAction);
            //        else if (currentInOutIndex == 1)
            //            easing = new CCEaseSineIn(coreAction);
            //        else
            //            easing = new CCEaseSineInOut(coreAction);

            //        break;
            //}

            nodeToAddTo.AddAction(coreAction);
            //nodeToAddTo.AddAction(easing ?? coreAction);
        }

    }
}

