import { useState, useEffect } from 'react'
import toast from 'react-hot-toast'
import { getVolunteers, getVolunteersBySkill, deleteVolunteer } from '../api'

export default function VolunteerList({ user }) {
  const [volunteers, setVolunteers] = useState([])
  const [skill, setSkill] = useState('')
  const [loading, setLoading] = useState(true)

  const load = async (filterSkill = '') => {
    setLoading(true)
    try {
      const data = filterSkill
        ? await getVolunteersBySkill(filterSkill)
        : await getVolunteers()
      setVolunteers(data)
    } catch {
      toast.error('שגיאה בטעינת הנתונים')
    } finally {
      setLoading(false)
    }
  }

  useEffect(() => { load() }, [])

  const handleDelete = (id, name) => {
    toast((t) => (
      <div style={{ textAlign: 'right' }}>
        <p>למחוק את <strong>{name}</strong>?</p>
        <div style={{ display: 'flex', gap: '0.5rem', marginTop: '0.5rem' }}>
          <button
            onClick={async () => {
              toast.dismiss(t.id)
              try {
                await deleteVolunteer(id)
                setVolunteers(v => v.filter(x => x.id !== id))
                toast.success('המתנדב נמחק')
              } catch {
                toast.error('שגיאה במחיקה - נדרשת הרשאת מנהל')
              }
            }}
            style={{ background: '#e53e3e', color: 'white', border: 'none', borderRadius: '6px', padding: '0.3rem 0.8rem', cursor: 'pointer' }}
          >מחק</button>
          <button
            onClick={() => toast.dismiss(t.id)}
            style={{ background: '#e2e8f0', border: 'none', borderRadius: '6px', padding: '0.3rem 0.8rem', cursor: 'pointer' }}
          >ביטול</button>
        </div>
      </div>
    ), { duration: 10000 })
  }

  return (
    <div className="section">
      <h2>רשימת מתנדבים</h2>
      <div className="filter-bar">
        <input
          placeholder="סנן לפי מיומנות..."
          value={skill}
          onChange={e => setSkill(e.target.value)}
          onKeyDown={e => e.key === 'Enter' && load(skill)}
        />
        <button onClick={() => load(skill)}>חפש</button>
        <button onClick={() => { setSkill(''); load('') }}>נקה</button>
      </div>

      {loading && <p className="loading">טוען...</p>}

      <div className="cards-grid">
        {volunteers.map(v => (
          <div key={v.id} className="card">
            <div className="card-header">
              <span className="avatar">{v.firstName?.[0]}{v.lastName?.[0]}</span>
              <div>
                <h3>{v.firstName} {v.lastName}</h3>
                <p className="email">{v.email}</p>
              </div>
            </div>
            {v.skills?.length > 0 && (
              <div className="skills">
                {v.skills.map(s => <span key={s} className="tag">{s}</span>)}
              </div>
            )}
            {user?.role === 'admin' && (
              <button className="delete-btn" onClick={() => handleDelete(v.id, `${v.firstName} ${v.lastName}`)}>🗑 מחק</button>
            )}
          </div>
        ))}
      </div>

      {!loading && volunteers.length === 0 && <p className="empty">לא נמצאו מתנדבים</p>}
    </div>
  )
}
