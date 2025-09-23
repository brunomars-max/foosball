using Raylib_cs;
using ball;
using feild;

football gameball = new football();


List<player> defenders = new List<player>()
{
new player(250,20),
new player(250,90),
new player(250,190),
new player(250,290)
};

List<player> midfielders = new List<player>()
{
new player(600,50),
new player(600,120),
new player(600,190),
};


List<player> attarkers = new List<player>()
{
new player(1000,20),
new player(1000,90),
new player(1000,190),
new player(1000,290)
};


gameball.x = 600;
gameball.y = 200;
gameball.speedx = -40;
gameball.speedy = 0;

int width = 1200;
int height = 400;

Raylib.InitWindow(width, height, "my game");


Rectangle leftgoalpost = new Rectangle(0, 175, 50, 100);
Rectangle rightgoalpost = new Rectangle(1150, 175, 50, 100);


while (!Raylib.WindowShouldClose())
{
    // detection on left goal post
    bool leftgoalhit = Raylib.CheckCollisionCircleRec(new System.Numerics.Vector2(gameball.x, gameball.y), 55, leftgoalpost);
    Raylib.BeginDrawing();
    if (leftgoalhit == true)
    {
        Console.WriteLine("goallllll!!!");
        gameball.x = width / 2;//reset
        gameball.y = height / 2; //reset
    }

    // detection on right goal post
    bool rightgoalhit = Raylib.CheckCollisionCircleRec(new System.Numerics.Vector2(gameball.x, gameball.y), 55, rightgoalpost);
    Raylib.BeginDrawing();
    if (rightgoalhit == true)
    {
        Console.WriteLine("goallllll!!!");
        gameball.x = width / 2;//reset
        gameball.y = height / 2; //reset
    }

    Raylib.ClearBackground(Color.Lime);

    Raylib.DrawCircleGradient((int)gameball.x, (int)gameball.y, 25, Color.DarkBlue, Color.Gold);

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
    Raylib.DrawRectangleRec(attarkers[3].rect, Color.Black);
    Raylib.EndDrawing();


    gameball.moveball();




    if (Raylib.IsKeyDown(KeyboardKey.W))
    {

        if (defenders[0].rect.Y > 0)
        {
            for (int number = 0; number < 4; number += 1)

                defenders[number].rect.Y -= 1;

        }

        if (midfielders[0].rect.Y > 0)
        {
            for (int number = 0; number < 3; number += 1)

                midfielders[number].rect.Y -= 1;

        }


        if (attarkers[0].rect.Y > 0)
        {
            for (int number = 0; number < 4; number += 1)

                attarkers[number].rect.Y -= 1;

        }



    }

    if (Raylib.IsKeyDown(KeyboardKey.S))
    {

        if (defenders[3].rect.Y < 365)
        {
            for (int number = 0; number < 4; number += 1)

                defenders[number].rect.Y += 1;

        }

        if (midfielders[2].rect.Y < 365)
        {
            for (int number = 0; number < 3; number += 1)

                midfielders[number].rect.Y += 1;

        }


        if (attarkers[3].rect.Y < 365)
        {
            for (int number = 0; number < 4; number += 1)

                attarkers[number].rect.Y += 1;

        }



    }

//check if player hit the ball
    for (int i=0;  i < 4 ;  i+=1)
{
bool answer = Raylib.CheckCollisionCircleRec(new System.Numerics.Vector2(gameball.x,gameball.y) , 25 , defenders[i].rect);

if (answer == true)
{

System.Numerics.Vector2 direction = new System.Numerics.Vector2(gameball.x - defenders[i].rect.X ,

                                                                 gameball.y - defenders[i].rect.Y);

double distance = Math.Sqrt(direction .X * direction .X + direction .Y * direction .Y );

direction .X = (float)(direction .X/distance);
direction .Y = (float)(direction .Y/distance);


int kickspeed = 40;

gameball.speedx = direction.X *kickspeed;
gameball.speedy = direction.Y *kickspeed;



gameball.x = defenders[i].rect.X + 25 + 25; 
}

}





}