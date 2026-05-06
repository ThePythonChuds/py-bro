using System;

namespace PyBro
{
	public class Coords
	{
		public Coords(uint row, uint col)
		{
			Row = row;
			Col = col;
		}

		public uint Row { get; set; }
		public uint Col { get; set; }
	}
}
