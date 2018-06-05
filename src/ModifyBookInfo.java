import java.io.*;

import javax.servlet.*;
import javax.servlet.http.*;


public class ModifyBookInfo extends HttpServlet{

	@Override
	public void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
		
		try {
			String location = req.getParameter("location");
			int chapter = Integer.parseInt(req.getParameter("chapter"));
			String content = req.getParameter("content");
			String path = String.format("%s%s/%d.txt", getServletContext().getRealPath("/book/"),location,chapter);
			FileWriter fw = new FileWriter(path);
			fw.write(content);
			fw.flush();
			fw.close();
		}catch (Exception e) {
			PrintWriter out = resp.getWriter();
			out.println(e.getMessage());
		}
	}
}
