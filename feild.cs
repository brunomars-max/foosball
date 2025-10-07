using Raylib_cs;

namespace feild
{

class player
{
	public float y;

	public float x ;

	public Rectangle rect;

	public player(float x , float y)
	{
		this.y = y;
		this.x = x;

		rect = new Rectangle(x , y , 45 , 45);
	}
}

}