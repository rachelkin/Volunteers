import { useState } from 'react'
import toast from 'react-hot-toast'
import { addVolunteer } from '../api'

export default function VolunteerForm({ onSuccess }) {
  const [form, setForm] = useState({
    firstName: '', lastName: '', email: '',
    phoneNumber: '', password: '', birthDate: '', skillId: 0
  })
  const [loading, setLoading] = useState(false)

  const set = (field) => (e) => setForm(f => ({ ...f, [field]: e.target.value }))

  const handleSubmit = async (e) => {
    e.preventDefault()
    setLoading(true)
    try {
      await addVolunteer({
        ...form,
        skillId: parseInt(form.skillId) || 0,
        birthDate: form.birthDate || null
      })
      toast.success('המתנדב נוסף בהצלחה!')
      onSuccess()
    } catch (err) {
      toast.error(err.message)
    } finally {
      setLoading(false)
    }
  }

  return (
    <div className="section">
      <h2>הוספת מתנדב חדש</h2>
      <form className="form-card" onSubmit={handleSubmit}>
        <div className="form-row">
          <input placeholder="שם פרטי *" value={form.firstName} onChange={set('firstName')} required />
          <input placeholder="שם משפחה *" value={form.lastName} onChange={set('lastName')} required />
        </div>
        <input placeholder="אימייל *" type="email" value={form.email} onChange={set('email')} required />
        <input placeholder="טלפון" value={form.phoneNumber} onChange={set('phoneNumber')} />
        <input placeholder="סיסמה" type="password" value={form.password} onChange={set('password')} />
        <label>תאריך לידה</label>
        <input type="date" value={form.birthDate} onChange={set('birthDate')} />
        <input placeholder="מזהה מיומנות (skillId)" type="number" value={form.skillId} onChange={set('skillId')} />
        <div className="form-actions">
          <button type="submit" disabled={loading}>{loading ? 'שומר...' : 'הוסף מתנדב'}</button>
          <button type="button" onClick={onSuccess} className="secondary">ביטול</button>
        </div>
      </form>
    </div>
  )
}
