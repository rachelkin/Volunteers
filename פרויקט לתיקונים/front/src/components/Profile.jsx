import { useState, useEffect } from 'react'
import toast from 'react-hot-toast'
import { getProfile, addSkillToVolunteer } from '../api'

export default function Profile() {
  const [profile, setProfile] = useState(null)
  const [skillName, setSkillName] = useState('')

  useEffect(() => {
    getProfile().then(setProfile).catch(() => toast.error('שגיאה בטעינת הפרופיל'))
  }, [])

  const handleAddSkill = async (e) => {
    e.preventDefault()
    try {
      await addSkillToVolunteer(skillName)
      toast.success('המיומנות נוספה בהצלחה!')
      setSkillName('')
      const updated = await getProfile()
      setProfile(updated)
    } catch (err) {
      toast.error(err.message)
    }
  }

  if (!profile) return <p className="loading">טוען פרופיל...</p>

  return (
    <div className="section">
      <h2>הפרופיל שלי</h2>
      <div className="profile-card">
        <div className="profile-avatar">{profile.firstName?.[0]}{profile.lastName?.[0]}</div>
        <h3>{profile.firstName} {profile.lastName}</h3>
        <p>{profile.email}</p>
        {profile.phoneNumber && <p>📞 {profile.phoneNumber}</p>}
        {profile.birthDate && <p>🎂 {new Date(profile.birthDate).toLocaleDateString('he-IL')}</p>}

        <div className="skills-section">
          <h4>המיומנויות שלי</h4>
          <div className="skills">
            {profile.skills?.length > 0
              ? profile.skills.map(s => <span key={s} className="tag">{s}</span>)
              : <span className="empty-inline">אין מיומנויות עדיין</span>}
          </div>
        </div>

        <form className="add-skill-form" onSubmit={handleAddSkill}>
          <input
            placeholder="הוסף מיומנות קיימת..."
            value={skillName}
            onChange={e => setSkillName(e.target.value)}
            required
          />
          <button type="submit">הוסף</button>
        </form>
      </div>
    </div>
  )
}
