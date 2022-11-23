import { createRouter, createWebHistory } from 'vue-router'

import Users from './components/Users.vue';
import Details from './components/Details.vue';
import Create from './components/Create.vue';
import Edit from './components/Edit.vue';
import Delete from './components/Delete.vue'

const routes = [
    { name: 'Users', path: '/', component: Users },
    { name: 'Details', path: '/Details/:id', component: Details },
    { name: 'Create', path: '/Create', component: Create },
    { name: 'Edit', path: '/Edit/:id', component: Edit },
    { name: 'Delete', path: '/Delete/:id', component: Delete }
]

const router = createRouter({
    history: createWebHistory(),
    routes
})
export default router;