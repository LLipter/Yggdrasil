import java.io.*;

import javax.servlet.*;
import javax.servlet.http.*;


public class ModifyBookContent extends HttpServlet{

	@Override
	public void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
		int location = Integer.parseInt(req.getParameter("location"));
		int chapter = Integer.parseInt(req.getParameter("chapter"));
		String content = req.getParameter("content");
		String path = String.format("%sbook/%s/%d.txt", getServletContext().getRealPath("/book/"),location,chapter);
		FileWriter file = new FileWriter(path,false);
		file.write(content);
	}
}
