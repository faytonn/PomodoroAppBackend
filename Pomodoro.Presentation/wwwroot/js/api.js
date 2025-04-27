const API_BASE_URL = '/api';

export const tasks = {
    async create(task) {
        try {
            const response = await fetch(`${API_BASE_URL}/PomodoroTasks`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('token')}`
                },
                body: JSON.stringify(task)
            });

            if (!response.ok) {
                throw new Error('Failed to create task');
            }

            return await response.json();
        } catch (error) {
            console.error('Error creating task:', error);
            throw error;
        }
    },

    async getAll() {
        try {
            const response = await fetch(`${API_BASE_URL}/PomodoroTasks`, {
                headers: {
                    'Authorization': `Bearer ${localStorage.getItem('token')}`
                }
            });

            if (!response.ok) {
                throw new Error('Failed to fetch tasks');
            }

            return await response.json();
        } catch (error) {
            console.error('Error fetching tasks:', error);
            throw error;
        }
    },

    async update(id, task) {
        try {
            const response = await fetch(`${API_BASE_URL}/PomodoroTasks/${id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${localStorage.getItem('token')}`
                },
                body: JSON.stringify(task)
            });

            if (!response.ok) {
                throw new Error('Failed to update task');
            }

            return true;
        } catch (error) {
            console.error('Error updating task:', error);
            throw error;
        }
    },

    async delete(id) {
        try {
            const response = await fetch(`${API_BASE_URL}/PomodoroTasks/${id}`, {
                method: 'DELETE',
                headers: {
                    'Authorization': `Bearer ${localStorage.getItem('token')}`
                }
            });

            if (!response.ok) {
                throw new Error('Failed to delete task');
            }

            // Check if there's any content to parse
            const contentType = response.headers.get('content-type');
            if (contentType && contentType.includes('application/json')) {
                return await response.json();
            }
            return true;
        } catch (error) {
            console.error('Error deleting task:', error);
            throw error;
        }
    }
}; 