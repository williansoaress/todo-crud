export interface User {
    id: number;
    name: string;
    password: string;
    todos: Todo[]; 
}
