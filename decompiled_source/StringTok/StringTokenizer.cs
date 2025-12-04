using System.Collections;

namespace StringTok;

public class StringTokenizer
{
	private int CurrIndex;

	private int NumTokens;

	private ArrayList tokens;

	private string StrSource;

	private string StrDelimiter;

	public string Source => StrSource;

	public string Delim => StrDelimiter;

	public StringTokenizer(string source, string delimiter)
	{
		tokens = new ArrayList(10);
		StrSource = source;
		StrDelimiter = delimiter;
		if (delimiter.Length == 0)
		{
			StrDelimiter = " ";
		}
		Tokenize();
	}

	public StringTokenizer(string source, char[] delimiter)
		: this(source, new string(delimiter))
	{
	}

	public StringTokenizer(string source)
		: this(source, "")
	{
	}

	public StringTokenizer()
		: this("", "")
	{
	}

	private void Tokenize()
	{
		string text = StrSource;
		string text2 = "";
		NumTokens = 0;
		tokens.Clear();
		CurrIndex = 0;
		if (text.IndexOfAny(StrDelimiter.ToCharArray()) < 0)
		{
			NumTokens = 1;
			CurrIndex = 0;
			tokens.Add(text);
			tokens.TrimToSize();
			text = "";
		}
		while (text.IndexOfAny(StrDelimiter.ToCharArray()) >= 0)
		{
			if (text.IndexOfAny(StrDelimiter.ToCharArray()) == 0)
			{
				text = ((text.Length <= 1) ? "" : text.Substring(1));
				continue;
			}
			text2 = text.Substring(0, text.IndexOfAny(StrDelimiter.ToCharArray()));
			tokens.Add(text2);
			text = ((text.Length <= text2.Length) ? "" : text.Substring(text2.Length));
		}
		if (text.Length > 0)
		{
			tokens.Add(text);
		}
		tokens.TrimToSize();
		NumTokens = tokens.Count;
	}

	public void NewSource(string newSrc)
	{
		StrSource = newSrc;
		Tokenize();
	}

	public void NewDelim(string newDel)
	{
		if (newDel.Length == 0)
		{
			StrDelimiter = " ";
		}
		else
		{
			StrDelimiter = newDel;
		}
		Tokenize();
	}

	public void NewDelim(char[] newDel)
	{
		string text = new string(newDel);
		if (text.Length == 0)
		{
			StrDelimiter = " ";
		}
		else
		{
			StrDelimiter = text;
		}
		Tokenize();
	}

	public int CountTokens()
	{
		return tokens.Count;
	}

	public bool HasMoreTokens()
	{
		if (CurrIndex <= tokens.Count - 1)
		{
			return true;
		}
		return false;
	}

	public string NextToken()
	{
		if (CurrIndex <= tokens.Count - 1)
		{
			string result = (string)tokens[CurrIndex];
			CurrIndex++;
			return result;
		}
		return null;
	}
}
