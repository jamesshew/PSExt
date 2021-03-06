using System;
using System.Diagnostics;
using System.Management.Automation.Host;
using System.Runtime.InteropServices;

namespace PSExt.Host
{
	internal class DbgEngineRawUserInterface : PSHostRawUserInterface
	{		
		private readonly Process _process;
		public DbgEngineRawUserInterface()
		{
			_process = System.Diagnostics.Process.GetCurrentProcess();			
		}
		/// <summary>
		///     Gets or sets the background color of text to be written.
		///     This implementation maps to the Console.Background property.
		/// </summary>
		public override ConsoleColor BackgroundColor
		{
			get { return ConsoleColor.White; }
			set {  }
		}

		/// <summary>
		///     Gets or sets the host buffer size. This implementation
		///     is adapted from the Console buffer APIs.
		/// </summary>
		public override Size BufferSize
		{
			get { return new Size(80, 1); }
			set {  }
		}

		/// <summary>
		///     Gets or sets the cursor position. This functionality is not
		///     implemented and the call fails with a NotImplementedException
		///     exception.
		/// </summary>
		public override Coordinates CursorPosition
		{
			get { return new Coordinates(0, 0); }
			set { }
		}

		/// <summary>
		///     Gets or sets the cursor size. This implementation maps to the
		///     Console.CursorSize property.
		/// </summary>
		public override int CursorSize
		{
			get { return 1; }
			set { }
		}

		/// <summary>
		///     Gets or sets the foreground color of the text to be written.
		///     This implementation maps to the Console.ForegroundColor
		///     property.
		/// </summary>
		public override ConsoleColor ForegroundColor
		{
			get { return ConsoleColor.Black; }
			set { }
		}

		/// <summary>
		///     Gets a value that indicates whether a key is available.
		///     This implementation maps to the Console.KeyAvailable property.
		/// </summary>
		public override bool KeyAvailable => false;

		/// <summary>
		///     Gets the maximum physical size of the window. This implementation is
		///     adapted from the Console.LargestWindowWidth and
		///     Console.LargestWindowHeight properties.
		/// </summary>
		public override Size MaxPhysicalWindowSize => new Size(80, 100);

		/// <summary>
		///     Gets the maximum window size. This implementation is adapted from
		///     the Console.LargestWindowWidth and Console.LargestWindowHeight
		///     properties.
		/// </summary>
		public override Size MaxWindowSize => new Size(80,100);

		/// <summary>
		///     Gets or sets the window position. This implementation is adapted from
		///     the Console window APIs.
		/// </summary>
		public override Coordinates WindowPosition
		{
			get { return new Coordinates(0,0); }
			set { }
		}

		/// <summary>
		///     Gets or sets the window size adapted from the corresponding .NET Console calls.
		/// </summary>
		public override Size WindowSize
		{
			get { return new Size(80,100); }
			set {  }
		}

		/// <summary>
		///     Gets or sets the title of the window. This implementation maps
		///     to the Console.Title property.
		/// </summary>
		public override string WindowTitle
		{
			get { return _process.MainWindowTitle; }
			set { SetWindowText(_process.MainWindowHandle, value); }
		}

		/// <summary>
		///     Resets the input buffer. This method is not currently
		///     implemented and returns silently.
		/// </summary>
		public override void FlushInputBuffer()
		{
			// Do nothing.
		}

		/// <summary>
		///     Retrieves a rectangular region of the screen buffer. This method
		///     is not implemented. The call fails with an exception.
		/// </summary>
		/// <param name="rectangle">A Rectangle object that defines the size of the rectangle</param>
		/// <returns>Throws a NotImplementedException exception.</returns>
		public override BufferCell[,] GetBufferContents(Rectangle rectangle)
		{
			throw new NotImplementedException("The GetBufferContents method is not implemented by MyRawUserInterface.");
		}

		/// <summary>
		///     Reads a pressed, released, or pressed and released keystroke
		///     from the keyboard device, blocking processing until a keystroke
		///     is typed that matches the specified keystroke options. This
		///     functionality is not implemented. The call fails with an
		///     exception.
		/// </summary>
		/// <param name="options">
		///     A bit mask of the options to be used when
		///     reading from the keyboard.
		/// </param>
		/// <returns>Throws a NotImplementedException exception.</returns>
		public override KeyInfo ReadKey(ReadKeyOptions options)
		{
			throw new NotImplementedException("The ReadKey() method is not implemented by MyRawUserInterface.");
		}

		/// <summary>
		///     Crops a region of the screen buffer. This functionality is not
		///     implemented. The call fails with an exception.
		/// </summary>
		/// <param name="source">
		///     A Rectangle structure that identifies the
		///     region of the screen to be scrolled.
		/// </param>
		/// <param name="destination">
		///     A Coordinates structure that
		///     identifies the upper-left coordinates of the region of the
		///     screen to receive the source region contents.
		/// </param>
		/// <param name="clip">
		///     A Rectangle structure that identifies the
		///     region of the screen to include in the operation.
		/// </param>
		/// <param name="fill">
		///     A BufferCell structure that identifies the
		///     character and attributes to be used to fill all cells within
		///     the intersection of the source rectangle and clip rectangle
		///     that are left "empty" by the move.
		/// </param>
		public override void ScrollBufferContents(Rectangle source, Coordinates destination, Rectangle clip, BufferCell fill)
		{
			throw new NotImplementedException("The ScrollBufferContents() method is not implemented by MyRawUserInterface.");
		}

		/// <summary>
		///     Copies a given character to a region of the screen buffer based
		///     on the coordinates of the region. This method is not implemented.
		///     The call fails with an exception.
		/// </summary>
		/// <param name="origin">The coordnates of the region.</param>
		/// <param name="contents">A BufferCell structure that defines the fill character.</param>
		public override void SetBufferContents(Coordinates origin, BufferCell[,] contents)
		{
			throw new NotImplementedException("The SetBufferContents() method is not implemented by MyRawUserInterface.");
		}

		/// <summary>
		///     Copies a given character to a rectangular region of the screen
		///     buffer. This method is not implemented. The call fails with an
		///     exception.
		/// </summary>
		/// <param name="rectangle">A Rectangle structure that defines the area to be filled.</param>
		/// <param name="fill">A BufferCell structure that defines the fill character.</param>
		public override void SetBufferContents(Rectangle rectangle, BufferCell fill)
		{
			throw new NotImplementedException("The SetBufferContents() method is not implemented by MyRawUserInterface.");
		}

		[DllImport("User32.dll")]
		static extern bool SetWindowText(IntPtr hWnd, string text);

	}
}