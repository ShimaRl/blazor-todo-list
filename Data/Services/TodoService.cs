namespace test_blazor.Data;

public class TodoService
{

    private List<TodoModel> todos = new(){
        new TodoModel(){ Id= "16acb87e0f974f31894695dc24e03082", Title= "Title1", Description= "Description1 Description1 Description1 Description1", IsDone=false, CreatedAt=DateTime.Now },
        new TodoModel(){ Id= "5fe7a545a94a4a88870b01475d88648f", Title= "Title2", Description= "Description2 Description2 Description2 Description2", IsDone=true, CreatedAt=DateTime.Now },
        new TodoModel(){ Id= "66c1f028c28449d3968e7ce8eebad45d", Title= "Title3", Description= "Description3 Description3 Description3 Description3", IsDone=false, CreatedAt=DateTime.Now },
        new TodoModel(){ Id= "c14073d415b947919eb794c5463ce819", Title= "Title4", Description= "Description4 Description4 Description4 Description4", IsDone=true, CreatedAt=DateTime.Now },
        new TodoModel(){ Id= "fb991a5061ba425c853a41db6228708e", Title= "Title5", Description= "Description5 Description5 Description5 Description5", IsDone=true, CreatedAt=DateTime.Now },
    };

    public Task<TodoModel[]> GetTodosAsync()
    {
        return Task.FromResult(todos.ToArray());
    }

    public Task<TodoModel?> GetTodoAsync(string todoId)
    {
        TodoModel? todo = todos.Find(x => x.Id == todoId);
        return Task.FromResult(todo);
    }

    public Task<TodoModel> CreateTodoAsync(TodoModel todo)
    {
        todo.Id = Guid.NewGuid().ToString("N");
        todo.CreatedAt = DateTime.Now;
        todos.Add(todo);
        return Task.FromResult(todo);
    }

    public Task<TodoModel?> DeleteTodoAsync(string todoId)
    {
        TodoModel? todo = todos.Find(x => x.Id == todoId);
        if (todo != null)
        {
            todos.Remove(todo);
        }
        return Task.FromResult(todo);
    }

    public Task<TodoModel> UpdateTodoAsync(TodoModel newTodo, string todoId)
    {
        int todoIndex = todos.FindIndex(x => x.Id == todoId);

        todos[todoIndex].Title = newTodo.Title;
        todos[todoIndex].Description = newTodo.Description;
        todos[todoIndex].IsDone = newTodo.IsDone;

        return Task.FromResult(todos[todoIndex]);
    }
}