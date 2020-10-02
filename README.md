# Arvis

This is a project to control 3D objects by hand in augmented reality.

## Journal

Link([here](https://github.com/ryulurala/Arvis/blob/master/Arvis_Journal.pdf))

## Generate virtual hand

![가상손-min](https://user-images.githubusercontent.com/44297538/71554026-2340dd00-2a5d-11ea-92dd-498606d9941f.gif)

Computer vision technology recognizes human hands and creates virtual hands within Unity.

## Extract coordinates of hands

To make the virtual hand as above, we need to extract the coordinates of the hand. So we need to extract the hand coordinates. And To extract it, the following process is required.

###### 1. Convert to HSV image

###### 2. Binarize the HSV image for detecting skin

###### 3. Remove face

###### 4. Detect contours and defects

###### 5. Reduce the number of defects

###### 6. Detect the center of hand

###### 7. Find the defects of fingertips

![이미지](https://user-images.githubusercontent.com/44297538/71554029-289e2780-2a5d-11ea-8311-94c66f48a949.gif)

## Control AR object

![농구공-min](https://user-images.githubusercontent.com/44297538/71554028-25a33700-2a5d-11ea-9621-2418b9f8902c.gif)

After the above process, you can touch the AR object with your hands.

![골인-min](https://user-images.githubusercontent.com/44297538/71554027-24720a00-2a5d-11ea-95ac-015020e35a23.gif)
![뽑기](https://user-images.githubusercontent.com/44297538/87217558-83f29000-c385-11ea-9c53-c897d88ead20.gif)

This may suggest a new game paradigm.
