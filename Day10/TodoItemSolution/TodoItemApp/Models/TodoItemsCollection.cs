using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApiServer.Models;
using System.Collections.Specialized;

namespace TodoItemApp.Models
{
    public class TodoItemsCollection : ObservableCollection<TodoItem>   // IList<TodoItem>, List<TodoItem>
    {
        public void CopyFrom(IEnumerable<TodoItem> todoItems) 
        {
            this.Items.Clear();         // ObservableCollection<T> 자체가 Items 속성을 가지고 있음. 모든 삭제 삭제
            
            foreach (TodoItem item in todoItems) 
            {
                this.Items.Add(item);       // 다시 하나씩 추가 
            }
            // 데이터가 바꼈어요 !
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
