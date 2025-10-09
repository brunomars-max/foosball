using Raylib_cs;

namespace ball
{

    class football
    {
        //postion
        public float y;
        public float x;

        //speed 
        public float speedx;
        public float speedy;



        //move movement
        public void moveball()
        {


            //gameball

            float distancex = speedx * Raylib.GetFrameTime();

            float distancey = speedy * Raylib.GetFrameTime();

            //ball postion

            x += distancex;
            y += distancey;

            //bounce  up,down
            if ((y + 55) > 772)
            {

                speedy = -speedy;
            }

            if ((y - 55) < 0)
            {

                speedy = -speedy;
            }



            //bounce  lefy , right
            if ((x + 55) > 1200)
            {
                speedx = -speedx;

            }

            if ((x - 55) < 0)
            {
                speedx = -speedx;
                
             }

        }

    }
}