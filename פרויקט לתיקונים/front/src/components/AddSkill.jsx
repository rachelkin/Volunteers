import { useState } from 'react'
import toast from 'react-hot-toast'
import { createSkill } from '../api'

export default function AddSkill({ onSuccess }) {
  const [name, setName] = useState('')
  const [loading, setLoading] = useState(false)

  const handleSubmit = async (e) => {
    e.preventDefault()
    setLoading(true)
    try {
      const skill = await createSkill(name)
      toast.success(`המיומנות "${skill.name}" נוצרה בהצלחה!`)
      setName('')
    } catch (err) {
      toast.error(err.message || 'המיומנות כבר קיימת')
    } finally {
      setLoading(false)
    }
  }

  return (
    <div className="section">
      <h2>➕ הוספת מיומנות חדשה למערכת</h2>
      <form className="form-card" onSubmit={handleSubmit}>
        <p style={{ color: '#718096', fontSize: '0.9rem' }}>
          הוספת מיומנות חדשה שתהיה זמינה לכל המתנדבים במערכת
        </p>
        <input
          placeholder="שם המיומנות..."
          value={name}
          onChange={e => setName(e.target.value)}
          required
        />
        <div className="form-actions">
          <button type="submit" disabled={loading}>
            {loading ? 'יוצר...' : 'צור מיומנות'}
          </button>
          <button type="button" className="secondary" onClick={onSuccess}>חזור</button>
        </div>
      </form>
    </div>
  )
}
