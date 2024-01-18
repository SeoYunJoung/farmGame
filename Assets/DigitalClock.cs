using UnityEngine;

public class DigitalClock : MonoBehaviour
{
    public Sprite[] numberSprites;
    public Sprite[] daySprites;
    public SpriteRenderer hourTensRenderer, hourOnesRenderer, minuteTensRenderer, minuteOnesRenderer, dayRenderer;

    void Start()
    {
        // Sprite sheet에서 스프라이트 로드
        numberSprites = Resources.LoadAll<Sprite>("NumberSpriteSheet");
        daySprites = Resources.LoadAll<Sprite>("DaySpriteSheet");
    }

    void Update()
    {
        float virtualTime = Time.time * 20 / 1440; // 가상의 시간 (하루가 20분)
        int hour = ((int)virtualTime) % 24;
        int minute = ((int)(virtualTime * 60)) % 60;
        int second = ((int)(virtualTime * 3600)) % 60;
        int day = ((int)virtualTime / 24) % 7; // 요일 (0 = Sunday, 1 = Monday, ..., 6 = Saturday)

        int hourTens = hour / 10;
        int hourOnes = hour % 10;
        int minuteTens = minute / 10;
        int minuteOnes = minute % 10;

        hourTensRenderer.sprite = numberSprites[hourTens];
        hourOnesRenderer.sprite = numberSprites[hourOnes];
        minuteTensRenderer.sprite = numberSprites[minuteTens];
        minuteOnesRenderer.sprite = numberSprites[minuteOnes];
        dayRenderer.sprite = daySprites[day];
    }
}