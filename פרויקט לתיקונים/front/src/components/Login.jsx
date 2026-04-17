import { useState } from 'react'
import toast from 'react-hot-toast'
import { login } from '../api'

export default function Login({ onLogin }) {
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [loading, setLoading] = useState(false)
  const [token, setToken] = useState('')

  const handleSubmit = async (e) => {
    e.preventDefault()
    setLoading(true)
    try {
      const t = await login(email, password)
      setToken(t)
      toast.success('הטוקן התקבל! נכנס למערכת...')
      setTimeout(() => onLogin(t), 1500)
    } catch {
      toast.error('אימייל או סיסמה שגויים')
    } finally {
      setLoading(false)
    }
  }

  return (
    <div className="login-page">
      <div className="login-card">
        <div className="login-logo">🤝</div>
        <h2>כניסה למערכת</h2>
        <form onSubmit={handleSubmit}>
          <input
            type="email"
            placeholder="אימייל"
            value={email}
            onChange={e => setEmail(e.target.value)}
            required
          />
          <input
            type="password"
            placeholder="סיסמה"
            value={password}
            onChange={e => setPassword(e.target.value)}
            required
          />
          <button type="submit" disabled={loading}>
            {loading ? 'מתחבר...' : 'כניסה'}
          </button>
        </form>

        {token && (
          <div className="token-box">
            <p className="token-label">🔑 הטוקן שלך:</p>
            <textarea readOnly value={token} rows={4} />
            <p className="token-hint">נכנס אוטומטית...</p>
          </div>
        )}
      </div>
    </div>
  )
}
