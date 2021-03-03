import { Component } from '@angular/core';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  loading = false;
  taskList = [];
  taskName: string = ""
  isEdit = false;
  constructor(private apiService: ApiService) {

    this.getTasks();

  }

  getTasks() {
    this.taskList = [];
    this.loading = true;
    this.apiService.getAllTaskList().subscribe(r => {
      this.taskList = r;
      this.taskList.forEach(t => {
        t.isEdit = false
      })
      this.loading = false;
    })
  }


  deleteTask(task) {
    this.apiService.deleteTask(task).subscribe(r => {
      if (r) {
        this.getTasks()
      }
    })
  }


  editTask(task) {
    task.taskName = task.taskNameNew
    this.apiService.updateTask(task).subscribe(r => {
      if (r) {
        this.getTasks()
      }
    })
  }

  createTask() {
    if (this.taskName.length == 0) {
      return;
    }
    var newTask = {
      taskName : this.taskName
    }
    this.apiService.createTask(newTask).subscribe(r => {
      if (r) {
        this.getTasks()
      }
    })
  }

  onClear() {
    this.taskName = '';
    return
  }
}
