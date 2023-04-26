# ChordsAPI

A Chord / Guitar Fingering API with the following endpoints:

## Get Requests:

### https://localhost:7163/api/chord - retrieves all chords
### https://localhost:7163/api/chord/{chordname} - retrieves requested chord
example: https://localhost:7163/api/chord/Am
### https://localhost:7163/api/chord/random - retrieves a random chord
### https://localhost:7163/api/chord/major - retrieves all major chords
### https://localhost:7163/api/chord/minor - retrieves all minor chords
### https://localhost:7163/api/fingering - retrieves all fingerings
### https://localhost:7163/api/fingering/{chordname} - retrieves requested fingering
example: https://localhost:7163/api/fingering/G
### https://localhost:7163/api/fingering/random - retrieves a random fingering
### https://localhost:7163/api/fingering/easy - retrieves all easy fingerings
### https://localhost:7163/api/fingering/intermediate - retrieves all intermediate fingerings
### https://localhost:7163/api/fingering/hard - retrieves all hard fingerings

### Sample Response Body:
```yaml
{
    "statusCode": 200,
    "statusDescription": "OK: A was found.",
    "chords": [
        {
            "chordId": 1,
            "chordName": "A",
            "notes": "A,C#,E",
            "chordRoot": "A",
            "chordType": "Major",
            "chordBass": "A",
            "fingeringId": 1,
            "fingering": null
        }
    ],
    "fingerings": []
}
```

## Post Requests:

### https://localhost:7163/api/chord - post a chord

### Sample Request Body:
```yaml
{
    "chordName": "A7",
    "notes": "A,C#,E,G",
    "chordRoot": "A",
    "chordType": "7",
    "chordBass": "A",
    "fingering": {
        "chordName": "A7",
        "stringPositions": "X02020",
        "fingering": "XX2X3X",
        "difficulty": "Easy"
    }
}
```

### Sample Response Body:
```yaml
{
    "statusCode": 400,
    "statusDescription": "OK: chord and its corresponding fingering was successfully added",
    "chords": [],
    "fingerings": []
}
```

## Delete Requests:

### https://localhost:7163/api/chord/{chordname} - deletes requested chord
example: https://localhost:7163/api/chord/F

### Sample Response Body:
```yaml
{
    "statusCode": 200,
    "statusDescription": "OK: F chord and its corresponding fingering was successfully removed",
    "chords": [],
    "fingerings": []
}
```

