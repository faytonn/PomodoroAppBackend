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

export const auth = {
    async register(userData) {
        try {
            console.log('Sending registration request:', userData);
            const response = await fetch(`${API_BASE_URL}/auth/register`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(userData)
            });

            console.log('Registration response status:', response.status);
            const responseData = await response.json();
            console.log('Registration response data:', responseData);

            if (!response.ok) {
                throw new Error(responseData.message || 'Registration failed');
            }

            return responseData;
        } catch (error) {
            console.error('Registration error:', error);
            throw error;
        }
    },

    async login(loginData) {
        try {
            const response = await fetch(`${API_BASE_URL}/auth/login`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(loginData)
            });

            if (!response.ok) {
                const errorData = await response.json();
                throw new Error(errorData.message || 'Login failed');
            }

            const data = await response.json();
            if (data.token) {
                localStorage.setItem('token', data.token);
            }
            return data;
        } catch (error) {
            console.error('Error logging in:', error);
            throw error;
        }
    }
}; 