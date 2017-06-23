#import "../../../Classes/Unity/LocationLib.h"

extern "C"{
    void testFunc()
    {
        //        NSLog(@"testFunc");
        //        float x = [LocationLib getX];
        //        float y = [LocationLib getY];
        //        float orientation = [LocationLib getRotation];
        //
        //        NSLog(@"x: %5.2f, y: %5.2f, orientation: %3.0f",x,y,orientation);
        
    }
    
    float getX()
    {
        float x = [LocationLib getX];
        return x;
    }
    
    float getY()
    {
        float y = [LocationLib getY];
        return y;
    }
}
