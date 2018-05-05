using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WE_Project.Model
{
    /// <summary>
    /// sys_resourse:实体类(属性说明自动提取数据库字段的描述信息)
    /// 用来显示树形列表用
    /// </summary>
    [Serializable]
    public partial class sys_Tree
    {
        public sys_Tree()
        { }

        #region Model

        private string _id;
        private string _pId;
        private string _name;
        private bool _checked;
        private bool _open;
        private bool _isparent;

        /// <summary>
        /// id
        /// </summary>
        public string id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 父id
        /// </summary>
        public string pId
        {
            set { _pId = value; }
            get { return _pId; }
        }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool checke
        {
            set { _checked = value; }
            get { return _checked; }
        }
        /// <summary>
        /// 是否展开
        /// </summary>
        public bool open
        {
            set { _open = value; }
            get { return _open; }
        }
        /// <summary>
        /// 是否父节点
        /// </summary>
        public bool isParent
        {
            set { _isparent = value; }
            get { return _isparent; }
        }

        #endregion Model
    }
}
