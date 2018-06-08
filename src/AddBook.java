import java.io.*;
import java.util.Base64;

import javax.servlet.*;
import javax.servlet.http.*;


public class AddBook extends HttpServlet{

	@Override
	public void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
		
		try {
			String location = req.getParameter("location");
			String info = req.getParameter("info");
			String cover = req.getParameter("cover");
			
			String dirpath = String.format("%s%s/", getServletContext().getRealPath("/book/"),location);
			File dir = new File(dirpath);
			if(!dir.exists())
				dir.mkdir();
			
			
			Base64.Decoder decoder = Base64.getDecoder();
			byte[] binaryCover = decoder.decode(cover);
			String coverpath = String.format("%s%s/cover.jpg", getServletContext().getRealPath("/book/"),location);
			FileOutputStream out = new FileOutputStream(coverpath);
			out.write(binaryCover);
			out.close();
			
			
			String infopath = String.format("%s%s/info.txt", getServletContext().getRealPath("/book/"),location);
			FileWriter fw = new FileWriter(infopath);
			fw.write(info);
			fw.close();
			
		}catch (Exception e) {
			PrintWriter out = resp.getWriter();
			out.println(e.getMessage());
		}
	}
}
