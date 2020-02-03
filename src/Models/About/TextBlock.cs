using System.ComponentModel.DataAnnotations.Schema;

namespace AscendedGuild.Models
{
	public class TextBlock
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int TextBlockId { get; set; }
		public string Name { get; set; }
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