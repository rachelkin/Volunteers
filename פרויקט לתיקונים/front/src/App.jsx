import { useState, useEffect } from 'react'
import { Toaster } from 'react-hot-toast'
import { parseToken } from './tokenUtils'
import Login from './components/Login'
import VolunteerList from './components/VolunteerList'
import VolunteerForm from './components/VolunteerForm'
import Profile from './components/Profile'
import AddSkill from './components/AddSkill'

export default function App() {
  const [token, setToken] = useState(localStorage.getItem('token'))
  const [view, setView] = useState('list')

  const user = token ? parseToken(token) : null

  useEffect(() => {
    if (token) localStorage.setItem('token', token)
    else localStorage.removeItem('token')
  }, [token])

  const logout = () => {
    setToken(null)
    setView('list')
  }

  if (!token) return (
    <>
      <Toaster position="top-center" />
      <Login onLogin={setToken} />
    </>
  )

  return (
    <div className="app">
      <Toaster position="top-center" />
      <nav>
        <h1>🤝 מערכת מתנדבים</h1>
        <div className="nav-buttons">
          <button onClick={() => setView('list')}>רשימת מתנדבים</button>
          <button onClick={() => setView('add')}>הוספת מתנדב</button>
          <button onClick={() => setView('profile')}>הפרופיל שלי</button>
          {user?.role === 'admin' && (
            <button onClick={() => setView('addSkill')} className="admin-btn">➕ מיומנות חדשה</button>
          )}
          <button onClick={logout} className="logout">התנתק</button>
        </div>
      </nav>
      <main>
        {view === 'list' && <VolunteerList user={user} />}
        {view === 'add' && <VolunteerForm onSuccess={() => setView('list')} />}
        {view === 'profile' && <Profile />}
        {view === 'addSkill' && user?.role === 'admin' && <AddSkill onSuccess={() => setView('list')} />}
      </main>
    </div>
  )
}
