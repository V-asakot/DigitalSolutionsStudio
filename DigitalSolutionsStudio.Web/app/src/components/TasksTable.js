import React, { useState, useEffect } from 'react';
import fetchTasks from '../services/TasksService';
import TASK_STATUSES from './Consts';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const TasksTable = () => {
  const [tasks, setTasks] = useState([]);
  useEffect(() => { 
    const fetchTasksAsync = async () => {
      const tasksData = await fetchTasks();
      setTasks(tasksData.tasks);
    };

    fetchTasksAsync().catch((error) => { toast.error("Tasks are not loaded") }); 
  }, []);

  return (
    <div>
      <h1>Task List</h1>
      <table>
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Description</th>
            <th>Status</th>
            <th>Creation Date</th>
            <th>Last Modified Date</th>
          </tr>
        </thead>
        <tbody>
          {tasks.map(task => (
            <tr key={task.id}>
              <td>{task.id}</td>
              <td>{task.name}</td>
              <td>{task.description}</td>
              <td>{TASK_STATUSES[task.status]}</td>
              <td>{new Date(task.creationDate).toLocaleString()}</td>
              <td>{new Date(task.lastModifiedDate).toLocaleString()}</td>
            </tr>
          ))}
        </tbody>
      </table>
      <ToastContainer
        position="top-right"
        autoClose={5000}
        hideProgressBar={false}
        newestOnTop={false}
        closeOnClick
        rtl={false}
        pauseOnFocusLoss
        draggable
        pauseOnHover
        theme="light"
      />
    </div>
  );
};

export default TasksTable;