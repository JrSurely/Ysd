using Hidistro.Entities.Settings;
using Hidistro.SqlDal.Settings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlPanel.Settings
{
    public static class MenuHelper
    {
        public static IList<MenuInfo> GetMenus(string shopMenuStyle)
        {
            MenuDao menuDao = new MenuDao();
            IList<MenuInfo> topMenus = menuDao.GetTopMenus();
            IList<MenuInfo> result = new List<MenuInfo>();
            if (topMenus != null && topMenus.Count > 0)
            {
                foreach (MenuInfo current in topMenus)
                {
                    IList<MenuInfo> menusByParentId = menuDao.GetMenusByParentId(current.MenuId);
                    if (shopMenuStyle != "1")
                    {
                        current.ShopMenuPic = "";
                    }
                    current.SubMenus = menusByParentId;
                    result.Add(current);
                }
            }
            return result;
        }

        public static IList<MenuInfo> GetMenusByParentId(int parentId)
        {
            return new MenuDao().GetMenusByParentId(parentId);
        }

        public static MenuInfo GetMenu(int menuId)
        {
            return new MenuDao().GetMenu(menuId);
        }

        public static IList<MenuInfo> GetTopMenus()
        {
            return new MenuDao().GetTopMenus();
        }

        public static bool CanAddMenu(int parentId)
        {
            IList<MenuInfo> menusByParentId = new MenuDao().GetMenusByParentId(parentId);
            bool result;
            if (menusByParentId == null || menusByParentId.Count == 0)
            {
                result = true;
            }
            else if (parentId == 0)
            {
                result = (menusByParentId.Count < 5);
            }
            else
            {
                result = (menusByParentId.Count < 5);
            }
            return result;
        }

        public static bool UpdateMenu(MenuInfo menu)
        {
            return new MenuDao().UpdateMenu(menu);
        }

        public static bool UpdateMenuName(MenuInfo menu)
        {
            return new MenuDao().UpdateMenuName(menu);
        }

        public static int SaveMenu(MenuInfo menu)
        {
            return new MenuDao().SaveMenu(menu);
        }

        public static bool DeleteMenu(int menuId)
        {
            return new MenuDao().DeleteMenu(menuId);
        }
    }
}
