const BASE = '/api'

const authHeaders = () => ({
  'Content-Type': 'application/json',
  Authorization: `Bearer ${localStorage.getItem('token')}`
})

export const login = async (email, password) => {
  const res = await fetch(`${BASE}/auth/login`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ email, password })
  })
  if (!res.ok) throw new Error('פרטי התחברות שגויים')
  const text = await res.text()
  // מסיר גרשיים אם הטוקן הוחזר כ-JSON string
  return text.replace(/^"|"$/g, '')
}

export const getVolunteers = async () => {
  const res = await fetch(`${BASE}/volunteers`)
  return res.json()
}

export const getVolunteersBySkill = async (skill) => {
  const res = await fetch(`${BASE}/volunteers/Skill-filter?skill=${encodeURIComponent(skill)}`)
  return res.json()
}

export const getProfile = async () => {
  const res = await fetch(`${BASE}/volunteers/profile`, { headers: authHeaders() })
  if (!res.ok) throw new Error('לא מורשה')
  return res.json()
}

export const addVolunteer = async (data) => {
  const res = await fetch(`${BASE}/volunteers`, {
    method: 'POST',
    headers: authHeaders(),
    body: JSON.stringify(data)
  })
  if (!res.ok) throw new Error('שגיאה בהוספת מתנדב')
}

export const addSkillToVolunteer = async (skillName) => {
  const res = await fetch(`${BASE}/volunteers/add-skill`, {
    method: 'POST',
    headers: authHeaders(),
    body: JSON.stringify(skillName)
  })
  if (!res.ok) throw new Error('שגיאה בהוספת מיומנות')
}

export const deleteVolunteer = async (id) => {
  const res = await fetch(`${BASE}/volunteers/${id}`, {
    method: 'DELETE',
    headers: authHeaders()
  })
  if (!res.ok) throw new Error('שגיאה במחיקה')
}

export const createSkill = async (skillName) => {
  const res = await fetch(`${BASE}/skills`, {
    method: 'POST',
    headers: authHeaders(),
    body: JSON.stringify(skillName)
  })
  if (!res.ok) throw new Error('שגיאה ביצירת מיומנות')
  return res.json()
}
