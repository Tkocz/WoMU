using WoMU_lab1.Models;

using System.Linq;
using System.Collections.Generic;

namespace WoMU_lab1.Controllers {

public class RelatedProducts {
    public static Article[] GetRelatedArticles(ArticleDBContext db, int aid, int n) {
        var q = from order in db.Order
                where order.OrderDetails.Any(od => od.Article.ArticleId == aid)
                select order.OrderDetails;

        var q3 = q.ToArray();

        Dictionary<int, int> dic = new Dictionary<int, int>();

        foreach (var odl in q3) {
            foreach (var od in odl) {
                int artId = od.Article.ArticleId;

                if (artId == aid)
                    continue;

                if (!dic.ContainsKey(artId))
                    dic[artId] = 0;

                dic[artId] = dic[artId] + 1;
            }
        }



        var q2 = from e in dic
                    orderby e.Value descending
                    select e.Key;

        q2 = q2.ToArray();

        List<Article> arts = new List<Article>();

        foreach (var id in q2) {
            arts.Add(db.Article.Where(a => a.ArticleId == id).Single());
        }

        return arts.ToArray();

    }
}

}
