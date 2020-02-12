using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AscendedGuild.Models.About
{
	/// <summary>
	///	Contains the content of the About blurb
	/// </summary>
	/// <remarks>
	/// Content is stored as MarkdownContent 
	/// and retrieved as HtmlContent for display
	/// </remarks>
	public class TextBlock
	{		
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int TextBlockId { get; set; }
		
		[Required]
		[StringLength(100)]		
		public string Name { get; set; }

		[Required]
		[StringLength(3_000)]
		public string MarkdownContent { get; set; }

		public string HtmlContent 
		{ 
			get
			{
				return new MarkdownSharp.Markdown().Transform(MarkdownContent);
			}
		}

		public TextBlock()
		{		
		}
	}
}