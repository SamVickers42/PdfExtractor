# PdfExtractor
Take a pipe delimited text file and extract give pages from a PDF document into a new PDF document

Application takes in a single argument: Path to a pipe-delimited text file with 4 columns, listed below:
  • Original PDF path - this is the path to the original PDF from which the application will extract a subset of pages
  • Start page - Start page of original PDF which the appliocation will use for extracting 
  • Page Count - number of pages to extract from the original PDF
  • New PDF filepath - file path and filename to save extracted pages 

In practice, the test input file is usually generated from a MS Sql procedure, but can be cobbled together however the user likes, so long as the formatting matches. See file ExampleInput.txt for example formatting.  
