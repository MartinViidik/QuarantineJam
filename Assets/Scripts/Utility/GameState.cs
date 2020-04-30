[System.Serializable]
public class GameState
{
    public float highscore;
    public float face;
    public float crowds;
    public float tp;
    public float house;
    public float masks;

    public GameState(float _score, float _face, float _crowds, float _tp, float _house, float _masks)
    {
        highscore = _score;
        face = _face;
        crowds = _crowds;
        tp = _tp;
        house = _house;
        masks = _masks;
    }
}
