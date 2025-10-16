using Raylib_cs;
using ball;
using feild;



football gameball = new football();


List<player> defenders = new List<player>()
{
new player(250,100),
new player(250,250),
new player(250,400),
new player(250,550)
};


List<player> midfielders = new List<player>()
{
new player(600,175),
new player(600,325),
new player(600,475),
};


List<player> attarkers = new List<player>()
{
new player(1000,145),
new player(1000,325),
new player(1000,515),
};



List<player> defendersOPP = new List<player>()
{
new player(400,100),
new player(400,250),
new player(400,400),
new player(400,550)
};


List<player> midfieldersOPP = new List<player>()
{
new player(650,175),
new player(650,325),
new player(650,475),
};


List<player> attarkersOPP = new List<player>()
{
new player(1100,145),
new player(1100,325),
new player(1100,515),
};

gameball.x = 600;
gameball.y = 200;
gameball.speedx = 40;
gameball.speedy = 40;

int width = 1200;
int height = 772;

Raylib.InitWindow(width, height, "my game");
Texture2D foosball = Raylib.LoadTexture("graph.jpg");

Rectangle leftgoalpost = new Rectangle(0, 175, 50, 100);
Rectangle rightgoalpost = new Rectangle(1150, 175, 50, 100);

void kickball(List<player> players, int numberoftheplayers)
{
    const float ballRadius = 50f;   // match your drawing/collision radius
    const float gap = 20f;           // small gap so ball sits outside the player
    const float kickSpeed = 600f;   // pixels per second (recommended). Adjust as needed.
    const float playerwidthheight = 50;

    for (int i = 0; i < numberoftheplayers; i++)
    {
        var pRect = players[i].rect;
        var playerCenter = new System.Numerics.Vector2(pRect.X + playerwidthheight / 2f, pRect.Y + playerwidthheight / 2f);

        // collision test (uses same radius)
        bool hascollided = Raylib.CheckCollisionCircleRec(new System.Numerics.Vector2(gameball.x, gameball.y), ballRadius, pRect);
        if (hascollided)
        {
            // compute direction from player center to ball (away from player)
            var dir = new System.Numerics.Vector2(gameball.x - playerCenter.X, gameball.y - playerCenter.Y);
            float dist = MathF.Sqrt(dir.X * dir.X + dir.Y * dir.Y);

            // avoid divide-by-zero; if exactly overlapping, kick to the right
            if (dist < 0.0001f)
            {
                dir = new System.Numerics.Vector2(1f, 0f);
                dist = 1f;
            }
            dir.X /= dist;
            dir.Y /= dist;

            // set speed (we use pixels/sec here — see note below)
            gameball.speedx = dir.X * kickSpeed;
            gameball.speedy = dir.Y * kickSpeed;

            // push the ball just outside the player
            float halfPlayer = playerwidthheight / 2f; // assumes square players; adapt if rectangular
            float pushDistance = halfPlayer + ballRadius + gap;
            gameball.x = playerCenter.X + dir.X * pushDistance;
            gameball.y = playerCenter.Y + dir.Y * pushDistance;

            // stop further kicks this frame
            break;
        }
    }
}


while (!Raylib.WindowShouldClose())
{
kickball(defenders,4); 
kickball(midfielders,3); 
kickball(attarkers,3); 


    // detection on left goal post
    bool leftgoalhit = Raylib.CheckCollisionCircleRec(new System.Numerics.Vector2(gameball.x, gameball.y), 55, leftgoalpost);
    Raylib.BeginDrawing();
    if (leftgoalhit == true)
    {
        Console.WriteLine("goallllll!!!");
       // gameball.x = width / 2;//reset
        // gameball.y = height / 2; //reset
    }

    // detection on right goal post
    bool rightgoalhit = Raylib.CheckCollisionCircleRec(new System.Numerics.Vector2(gameball.x, gameball.y), 55, rightgoalpost);
    Raylib.BeginDrawing();
    if (rightgoalhit == true)
    {
        Console.WriteLine("goallllll!!!");
        // gameball.x = width / 2;//reset
        // gameball.y = height / 2; //reset
    }

    Raylib.ClearBackground(Color.Lime);

    Raylib.DrawTexture(foosball, 0, 0, Color.White);


    Raylib.DrawCircleGradient((int)gameball.x, (int)gameball.y, 35, Color.DarkBlue, Color.Gold);

    Raylib.DrawRectangleRec(leftgoalpost, Color.White);
    Raylib.DrawRectangleRec(rightgoalpost, Color.White);

    Raylib.DrawRectangleRec(defenders[0].rect, Color.Black);
    Raylib.DrawRectangleRec(defenders[1].rect, Color.Black);
    Raylib.DrawRectangleRec(defenders[2].rect, Color.Black);
    Raylib.DrawRectangleRec(defenders[3].rect, Color.Black);

    Raylib.DrawRectangleRec(midfielders[0].rect, Color.Black);
    Raylib.DrawRectangleRec(midfielders[1].rect, Color.Black);
    Raylib.DrawRectangleRec(midfielders[2].rect, Color.Black);


    Raylib.DrawRectangleRec(attarkers[0].rect, Color.Black);
    Raylib.DrawRectangleRec(attarkers[1].rect, Color.Black);
    Raylib.DrawRectangleRec(attarkers[2].rect, Color.Black);

    //opp

     Raylib.DrawRectangleRec(defendersOPP[0].rect, Color.Green);
    Raylib.DrawRectangleRec(defendersOPP[1].rect, Color.Green);
    Raylib.DrawRectangleRec(defendersOPP[2].rect, Color.Green);
    Raylib.DrawRectangleRec(defendersOPP[3].rect, Color.Green);

    Raylib.DrawRectangleRec(midfieldersOPP[0].rect, Color.Green);
    Raylib.DrawRectangleRec(midfieldersOPP[1].rect, Color.Green);
    Raylib.DrawRectangleRec(midfieldersOPP[2].rect, Color.Green);


    Raylib.DrawRectangleRec(attarkersOPP[0].rect, Color.Green);
    Raylib.DrawRectangleRec(attarkersOPP[1].rect, Color.Green);
    Raylib.DrawRectangleRec(attarkersOPP[2].rect, Color.Green);

    System.Numerics.Vector2 startpos_defenders = new System.Numerics.Vector2(defenders[0].rect.X , defenders[0].rect.Y);
    System.Numerics.Vector2 endpos_defenders = new System.Numerics.Vector2(defenders[3].rect.X , defenders[3].rect.Y);

        System.Numerics.Vector2 startpos_midfielders = new System.Numerics.Vector2(midfielders[0].rect.X , midfielders[0].rect.Y);
    System.Numerics.Vector2 endpos_midfielders = new System.Numerics.Vector2(midfielders[2].rect.X , midfielders[2].rect.Y);

      System.Numerics.Vector2 startpos_attarkers= new System.Numerics.Vector2(attarkers[0].rect.X , attarkers[0].rect.Y);
    System.Numerics.Vector2 endpos_attarkers = new System.Numerics.Vector2(attarkers[2].rect.X , attarkers[2].rect.Y);

    System.Numerics.Vector2 startpos_defendersOPP = new System.Numerics.Vector2(defendersOPP[0].rect.X , defendersOPP[0].rect.Y);
    System.Numerics.Vector2 endpos_defendersOPP = new System.Numerics.Vector2(defendersOPP[3].rect.X , defendersOPP[3].rect.Y);

     System.Numerics.Vector2 startpos_midfieldersOPP = new System.Numerics.Vector2(midfieldersOPP[0].rect.X , midfieldersOPP[0].rect.Y);
    System.Numerics.Vector2 endpos_midfieldersOPP = new System.Numerics.Vector2(midfielders[2].rect.X , midfieldersOPP[2].rect.Y);

      System.Numerics.Vector2 startpos_attarkersOPP= new System.Numerics.Vector2(attarkersOPP[0].rect.X , attarkersOPP[0].rect.Y);
    System.Numerics.Vector2 endpos_attarkersOPP = new System.Numerics.Vector2(attarkersOPP[2].rect.X , attarkersOPP[2].rect.Y);
    Raylib.DrawLineEx(startpos_defenders , endpos_defenders , 10 , Color.White);    

    
    Raylib.EndDrawing();


    gameball.moveball();




    if (Raylib.IsKeyDown(KeyboardKey.W))
    {

        if (defenders[0].rect.Y > 0)
        {
            for (int number = 0; number < 4; number += 1)

                defenders[number].rect.Y -= 5;

        }

        if (midfielders[0].rect.Y > 0)
        {
            for (int number = 0; number < 3; number += 1)

                midfielders[number].rect.Y -= 5;

        }


        if (attarkers[0].rect.Y > 0)
        {
            for (int number = 0; number < 3; number += 1)

                attarkers[number].rect.Y -= 5;

        }

      if (defendersOPP[0].rect.Y > 0)
        {
            for (int number = 0; number < 4; number += 1)

                defenders[number].rect.Y -= 5;

        }

        if (midfieldersOPP[0].rect.Y > 0)
        {
            for (int number = 0; number < 3; number += 1)

                midfielders[number].rect.Y -= 5;

        }


        if (attarkersOPP[0].rect.Y > 0)
        {
            for (int number = 0; number < 3; number += 1)

                attarkers[number].rect.Y -= 5;

        }



    }

    if (Raylib.IsKeyDown(KeyboardKey.S))
    {

        if (defenders[3].rect.Y < height - 35)
        {
            for (int number = 0; number < 4; number += 1)

                defenders[number].rect.Y += 5;

        }

        if (midfielders[2].rect.Y < height - 35)
        {
            for (int number = 0; number < 3; number += 1)

                midfielders[number].rect.Y += 5;

        }


        if (attarkers[2].rect.Y < height - 35)
        {
            for (int number = 0; number < 3; number += 1)

                attarkers[number].rect.Y += 5;

        }



        if (defendersOPP[3].rect.Y < height - 35)
        {
            for (int number = 0; number < 4; number += 1)

                defenders[number].rect.Y += 5;

        }

        if (midfieldersOPP[2].rect.Y < height - 35)
        {
            for (int number = 0; number < 3; number += 1)

                midfielders[number].rect.Y += 5;

        }


        if (attarkersOPP[2].rect.Y < height - 35)
        {
            for (int number = 0; number < 3; number += 1)

                attarkers[number].rect.Y += 5;

        }

    }

  
}