﻿namespace SVTextCutter.Format;

public sealed class Header
{
	public string? Target { get; set; }
	public int FormatVersion { get; set; }
	public bool Hidef { get; set; }
	public bool Compressed { get; set; }
}